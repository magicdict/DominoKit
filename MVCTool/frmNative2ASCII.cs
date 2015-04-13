using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (!String.IsNullOrEmpty(txtNative.Text))
            {
                txtASCII.Text = Common.Native2AsciiUtils.native2Ascii(txtNative.Text);
                return;
            }
            if (!String.IsNullOrEmpty(txtASCII.Text))
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
            if (!String.IsNullOrEmpty(txtDocumentPath.Text)) Common.Native2AsciiUtils.BatchConvert(txtDocumentPath.Text);
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
