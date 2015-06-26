using DevKit.Common;
using DevKit.MVCTool;
using System;
using System.IO;
using System.Windows.Forms;

namespace DevKit
{
    public partial class ModelCodeGenerator : Form
    {
        public ModelCodeGenerator()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDocumentPath_Click(object sender, EventArgs e)
        {
            txtDocumentPath.Text = Common.Utility.PickFile(Common.Utility.FileDialogMode.Open, Common.Utility.XlsxFilter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPageSourcePath_Click(object sender, EventArgs e)
        {
            if (radCSharpMVC5.Checked)
            {
                txtViewSourcePath.Text = Common.Utility.PickFile(Common.Utility.FileDialogMode.Save, Common.Utility.CSHTMLFilter);
            }
        }
        /// <summary>
        /// Sql Path Pick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSqlPath_Click(object sender, EventArgs e)
        {
            txtSqlPath.Text = Common.Utility.PickFile(Common.Utility.FileDialogMode.Save, Common.Utility.SqlFilter);
        }
        /// <summary>
        /// Source Code Pick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSourcePath_Click(object sender, EventArgs e)
        {
            if (radCSharpMVC5.Checked)
            {
                txtModelSourcePath.Text = Common.Utility.PickFile(Common.Utility.FileDialogMode.Save, Common.Utility.CSFilter);
            }
            if (radJavaSpring.Checked)
            {
                txtModelSourcePath.Text = Common.Utility.PickFile(Common.Utility.FileDialogMode.Save, Common.Utility.JavaFilter);
            }
            if (radJavaStruts2.Checked)
            {
                txtModelSourcePath.Text = Common.Utility.PickFile(Common.Utility.FileDialogMode.Save, Common.Utility.XmlFilter);
            }
        }

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGernerateCode_Click(object sender, EventArgs e)
        {
            ModelInfo model = ModelUtility.ReadModelFromExcel(txtDocumentPath.Text);
            FileInfo f = new FileInfo(txtDocumentPath.Text);
            if (string.IsNullOrEmpty(txtModelSourcePath.Text))
            {
                if (model.ModelName.StartsWith(EnumAndConst.MasterPrefix))
                {
                    txtModelSourcePath.Text = SystemMonitor.CurrentProject.MasterPath.SourcePath + "\\" + f.Name.Replace(".xlsx", ".cs");
                }
                else
                {
                    txtModelSourcePath.Text = SystemMonitor.CurrentProject.EntityPath.SourcePath + "\\" + f.Name.Replace(".xlsx", ".cs");
                }
            }
            if (string.IsNullOrEmpty(txtViewSourcePath.Text))
            {
                txtViewSourcePath.Text = SystemMonitor.CurrentProject.ViewerPath + "\\" + f.Name.Replace(".xlsx", ".cshtml");
            }
            if (radCSharpMVC5.Checked)
            {
                if (chkCreateModel.Checked)
                {
                    ModelGenerator.GenerateCSharp(txtModelSourcePath.Text, model, model.Items);
                }
                if (chkCreateView.Checked)
                {
                    ViewerGenerator.GenerateCSharp(txtViewSourcePath.Text, model, model.Items);
                }
            }
            if (radJavaSpring.Checked)
            {
                ModelGenerator.GenerateJavaSpring(txtModelSourcePath.Text, model);
            }
            if (radJavaStruts2.Checked)
            {
                ModelGenerator.GenerateJavaStruct2(txtModelSourcePath.Text, model);
            }
            //建表Sql文
            if (chkCreateDDL.Checked && (!string.IsNullOrEmpty(txtSqlPath.Text)))
            {
                DDLGenerator.MySql(model, txtSqlPath.Text);
            }
            GC.Collect();
            MessageBox.Show("代码生成完毕！");
        }
    }
}
