using System;
using System.Windows.Forms;

namespace DevKit.MVCTool
{
    public partial class frmValidationStruts2 : Form
    {
        public frmValidationStruts2()
        {
            InitializeComponent();
        }

        private void btnGernerateCode_Click(object sender, EventArgs e)
        {
            ModelInfo model = ModelUtility.ReadModelFromExcel(txtDocumentPath.Text);
            string xmlfilename = txtSourcePath.Text + "\\" + txtAction.Text + "Action-validation.xml";
            ValidationStruts2.GenerateValidation(xmlfilename, model,chkExternProperties.Checked);
            MessageBox.Show("验证文件已经生成：" + xmlfilename);
        }

        private void btnDocumentPath_Click(object sender, EventArgs e)
        {
            txtDocumentPath.Text = Common.Utility.PickFile(Common.Utility.FileDialogMode.Open, Common.Utility.XlsxFilter);
        }

        private void btnSourcePath_Click(object sender, EventArgs e)
        {
            txtSourcePath.Text = Common.Utility.PickFolder();
        }
    }
}
