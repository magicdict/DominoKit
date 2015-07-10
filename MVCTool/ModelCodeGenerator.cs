using DevKit.Common;
using DevKit.MVCTool;
using System;
using System.IO;
using System.Windows.Forms;

namespace DevKit
{
    public partial class ModelCodeGenerator : Form
    {

        public static ProjectInfo CurrentProject = null;

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
                string extendsion = ".cs";
                if (radJavaSpring.Checked || radJavaStruts2.Checked) {
                    extendsion = ".java";
                }
                if (model.ModelName.StartsWith(EnumAndConst.MasterPrefix))
                {
                    txtModelSourcePath.Text = CurrentProject.MasterPath.SourcePath + "\\" + f.Name.Replace(".xlsx", extendsion);
                }
                else
                {
                    txtModelSourcePath.Text = CurrentProject.EntityPath.SourcePath + "\\" + f.Name.Replace(".xlsx", extendsion);
                }
            }
            if (string.IsNullOrEmpty(txtViewSourcePath.Text))
            {
                string extendsion = ".cshtml";
                if (radJavaSpring.Checked || radJavaStruts2.Checked)
                {
                    extendsion = ".jsp";
                }
                txtViewSourcePath.Text = CurrentProject.ViewerPath + "\\" + f.Name.Replace(".xlsx", extendsion);
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
                ModelGenerator.GenerateJavaSpring(txtModelSourcePath.Text, model,chkHibernateORM.Checked);
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
