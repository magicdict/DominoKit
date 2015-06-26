using System;
using System.Windows.Forms;

namespace DevKit.MVCTool
{
    public partial class frmNative2ASCII : Form
    {
        public frmNative2ASCII()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 变换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNative.Text))
            {
                txtASCII.Text = Common.Native2AsciiUtils.native2Ascii(txtNative.Text);
                return;
            }
            if (!string.IsNullOrEmpty(txtASCII.Text))
            {
                txtNative.Text = Common.Native2AsciiUtils.ascii2Native(txtASCII.Text);
            }
        }
        /// <summary>
        /// 批量变换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBatchConvert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDocumentPath.Text)) Common.Native2AsciiUtils.BatchConvert(txtDocumentPath.Text);
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
    }
}
