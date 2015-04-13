using System;
using System.Windows.Forms;

namespace DevKit.MVCTool
{
	public partial class frmEnumCodeGenerator : Form
	{
		public frmEnumCodeGenerator()
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
		private void btnSourcePath_Click(object sender, EventArgs e)
		{
			txtSourcePath.Text = Common.Utility.PickFile(Common.Utility.FileDialogMode.Save, Common.Utility.CSFilter);
		}
		/// <summary>
		/// 生成代码
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGernerateCode_Click(object sender, EventArgs e)
		{
			EnumGenerator.Generate(txtDocumentPath.Text, txtSourcePath.Text);
		}
	}
}
