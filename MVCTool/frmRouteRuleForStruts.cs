using System;
using System.Windows.Forms;

namespace DevKit.MVCTool
{
    public partial class frmRouteRuleForStruts : Form
    {
        public frmRouteRuleForStruts()
        {
            InitializeComponent();
        }

        private void btnGernerateCode_Click(object sender, EventArgs e)
        {
            Struts2RouteRule.GenerateRouteXml(txtDocumentPath.Text, txtSourcePath.Text, txtPackage.Text);
        }

        private void btnDocumentPath_Click(object sender, EventArgs e)
        {
            txtDocumentPath.Text = Common.Utility.PickFile(Common.Utility.FileDialogMode.Open, Common.Utility.XlsxFilter);
        }

        private void btnSourcePath_Click(object sender, EventArgs e)
        {
            txtSourcePath.Text = Common.Utility.PickFile(Common.Utility.FileDialogMode.Save, Common.Utility.XmlFilter);
        }
    }
}
