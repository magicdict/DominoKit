using System;
using System.Windows.Forms;
using DevKit.CodeSnippetMgr;
using DevKit.MVCTool;


namespace DevKit
{
    public partial class Main : Form
    {
        #region"方法"
        public Main()
        {
            InitializeComponent();
            Text += " ver - " + Application.ProductVersion;
            ProjectToolStripMenuItem.Enabled = false;
            //开发中的内容，暂时不可用
            NETMVCRouteEditorToolStripMenuItem.Text += "[开发中]";
            NETMVCRouteEditorToolStripMenuItem.Enabled = false;
            //加载知识库
            LoadCodeSnappet();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenNode(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null)
                return;
            string strTag = e.Node.Tag.ToString();
            const string sourceCode = "SourceCode:";
            if (strTag.StartsWith(sourceCode, StringComparison.Ordinal))
            {
                string filename = strTag.Substring(sourceCode.Length);
                ShowTextFile(filename);
                return;
            }
            const string codeSnippet = "codeSnippet:";
            if (strTag.StartsWith(codeSnippet, StringComparison.Ordinal))
            {
                string DBID = strTag.Substring(codeSnippet.Length);
                ShowCodeSnippet(DBID);
                return;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        private void ShowTextFile(string filename)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            var t = new TextBox();
            t.Multiline = true;
            var sr = new System.IO.StreamReader(filename);
            t.Text = sr.ReadToEnd();
            sr.Close();
            this.splitContainer1.Panel2.Controls.Add(t);
            t.Dock = DockStyle.Fill;
            t.ScrollBars = ScrollBars.Both;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DBID"></param>
        private void ShowCodeSnippet(string DBID)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            var t = new TextBox();
            t.Multiline = true;
            t.Text = SystemMonitor.db.SearchAsSimpleRecordByDBID(DBID).Code.Replace("\n", System.Environment.NewLine);
            this.splitContainer1.Panel2.Controls.Add(t);
            t.Dock = DockStyle.Fill;
            t.ScrollBars = ScrollBars.Both;
        }
        #endregion

        #region "菜单"
        /// <summary>
        /// 新建工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPrjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var proj = new ProjectInfo();
            var frm = new frmNewProject(proj);
            Common.Utility.SetUp(frm);
            if (string.IsNullOrEmpty(proj.Name))
                return;
            RefreshProjectStatus(proj);
        }

        private void RefreshProjectStatus(ProjectInfo proj)
        {
            //初始化目录
            proj.InitFolder();
            //树型结构表示
            proj.SetProjectTree(this.trvProject);
            //当前工程
            SystemMonitor.CurrentProject = proj;
            //ModelGenerator设定
            ModelGenerator.proinfo = proj;
            EnumGenerator.proinfo = proj;
            //恢复菜单
            ProjectToolStripMenuItem.Enabled = true;
        }
        /// <summary>
        /// 打开工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenPrjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string projectfile = Common.Utility.PickFile(Common.Utility.FileDialogMode.Open, Common.Utility.XmlFilter);
            if (string.IsNullOrEmpty(projectfile)) return;
            ProjectInfo proj = Common.Utility.LoadObjFromXml<ProjectInfo>(projectfile);
            RefreshProjectStatus(proj);
        }

        /// <summary>
        /// 增加模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ModelName = Common.Utility.InputBox("请输入模型名称：");
            if (!string.IsNullOrEmpty(ModelName))
            {
                SystemMonitor.CurrentProject.NewModel(ModelName);
                SystemMonitor.CurrentProject.SetProjectTree(this.trvProject);
            }
        }
        /// <summary>
        /// 生成所有数据模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateAllModelCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemMonitor.CurrentProject.GenerateAllModelCode(SystemMonitor.CurrentProject.EntityPath);
            SystemMonitor.CurrentProject.SetProjectTree(this.trvProject);
        }
        /// <summary>
        /// 生成数据模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateModelCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Utility.SetUp(new ModelCodeGenerator());
        }
        /// <summary>
        /// 增加枚举
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewEnumStripMenuItem_Click(object sender, EventArgs e)
        {
            string EnumName = Common.Utility.InputBox("请输入枚举名称：");
            if (!string.IsNullOrEmpty(EnumName))
            {
                SystemMonitor.CurrentProject.NewEnum(EnumName);
                SystemMonitor.CurrentProject.SetProjectTree(this.trvProject);
            }
        }
        /// <summary>
        /// 生成所有枚举模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateAllEnumCodetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemMonitor.CurrentProject.GenerateAllEnumCode();
            SystemMonitor.CurrentProject.SetProjectTree(this.trvProject);
        }
        /// <summary>
        /// 枚举工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateEnumCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Utility.SetUp(new frmEnumCodeGenerator());
        }
        /// <summary>
        /// 增加辅助表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string MasterName = Common.Utility.InputBox("请输入辅助表名称：");
            if (!MasterName.StartsWith("M_"))
            {
                Common.Utility.MessageBox("辅助表名称必须以\"M_\"开头");
                return;
            }

            if (!string.IsNullOrEmpty(MasterName))
            {
                SystemMonitor.CurrentProject.NewModel(MasterName);
                SystemMonitor.CurrentProject.SetProjectTree(this.trvProject);
            }
        }
        /// <summary>
        /// 生成所有辅助表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateAllMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemMonitor.CurrentProject.GenerateAllModelCode(SystemMonitor.CurrentProject.MasterPath);
            SystemMonitor.CurrentProject.SetProjectTree(this.trvProject);
        }
        /// <summary>
        /// 生成辅助表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Utility.SetUp(new ModelCodeGenerator());
        }
        /// <summary>
        /// 生成所有代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateAllCodetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemMonitor.CurrentProject.GenerateAllModelCode(SystemMonitor.CurrentProject.EntityPath);
            SystemMonitor.CurrentProject.GenerateAllModelCode(SystemMonitor.CurrentProject.MasterPath);
            SystemMonitor.CurrentProject.GenerateAllEnumCode();
            SystemMonitor.CurrentProject.SetProjectTree(this.trvProject);
        }
        private void ExportToPrjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemMonitor.CurrentProject.CopyToProJ();
        }
        /// <summary>
        /// 工程的刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemMonitor.CurrentProject.SetProjectTree(this.trvProject);
        }
        /// <summary>
        /// 修改工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyPrjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmNewProject(SystemMonitor.CurrentProject);
            Common.Utility.SetUp(frm);
            RefreshProjectStatus(SystemMonitor.CurrentProject);
        }
        /// <summary>
        /// Native2ASCII
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void native2ASCIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Utility.SetUp(new frmNative2ASCII());
        }
        /// <summary>
        /// NET MVC 路由编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NETMVCRouteEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Utility.SetUp(new frmRouteRuleGenerater());
        }
        /// <summary>
        /// struts2 路由编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void struts2路由编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Utility.SetUp(new frmRouteRuleForStruts());
        }
        /// <summary>
        /// struts2数据验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void struts2数据验证ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Utility.SetUp(new frmValidationStruts2());
        }
        /// <summary>
        /// 代码示例
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void 代码示例ToolStripMenuItemClick(object sender, EventArgs e)
        {
            Common.Utility.SetUp(new frmCodeSnapList(SystemMonitor.CodeSnapDBFile));
        }

        void LoadCodeSnappet()
        {
            var lst = SystemMonitor.db.SearchAsDBRecord((x) => true);
            foreach (var element in lst)
            {
                var code = new TreeNode(element.DataRec.Title);
                code.Tag = "codeSnippet:" + element.DBId;
                trvCodeSnippet.Nodes.Add(code);
            }
        }
        /// <summary>
        /// 使用手册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 使用手册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\开发辅助工具使用手册.xlsx");
        }
        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strAbout = string.Format("MVC开发辅助工具{0}版本号：{1}{2}版权所有：上海中和软件公司{2}研发部门：信息技术推进室 2014 - 2015",
                                  Environment.NewLine, Application.ProductVersion, Environment.NewLine);
            MessageBox.Show(strAbout, "关于");
        }





        #endregion


    }
}
