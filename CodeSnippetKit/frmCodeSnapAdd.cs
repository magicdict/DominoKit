/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2014/12/30
 * Time: 14:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using DevKit.Common;

namespace DevKit.CodeSnippetMgr
{
	/// <summary>
	/// Description of frmCodeManager.
	/// </summary>
	public partial class frmCodeSnapAdd : Form
	{
		/// <summary>
		/// 数据库
		/// </summary>
		Common.XmlDataBase<codeSnippet> db;
		/// <summary>
		/// 数据库文件名称
		/// </summary>
		string _dbfile = string.Empty;
		/// <summary>
		/// 编辑模式下的DBID号码
		/// </summary>
		string _dbid = string.Empty;
		/// <summary>
		/// 领域数据
		/// </summary>
		codeSnippet code = new codeSnippet();
		/// <summary>
		/// 数据模型
		/// </summary>
		Model<codeSnippet> model;
		public frmCodeSnapAdd(string dbfile, string DBID = "")
		{
			_dbfile = dbfile;
			
			_dbid = DBID;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FrmCodeManagerLoad(object sender, EventArgs e)
		{
			db = new Common.XmlDataBase<codeSnippet>(_dbfile);
            Utility.FillComberWithArray(cmbCatalog, codeSnippet.strCatalog);
			if (!string.IsNullOrEmpty(_dbid)) {
				model = db.SearchAsDBRecordByDBID(_dbid);
				code = model.DataRec;
				txtTitle.Text = code.Title;
				txtDescription.Text = code.Descrpition;
				txtTag.Text = code.Tag;
				txtCode.Text = code.Code.Replace("\n",System.Environment.NewLine);
				cmbCatalog.Text = code.Catalog;
				btnAppend.Text = "更新";
			}
		}
		/// <summary>
		/// 添加代码片断
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void BtnAppendClick(object sender, EventArgs e)
		{
			code.Title = txtTitle.Text;
			code.Descrpition = txtDescription.Text;
			code.Tag = txtTag.Text;
			code.Code = txtCode.Text;
			code.Catalog = cmbCatalog.Text;
			if (!string.IsNullOrEmpty(_dbid)) {
				db.UpdataRec(model);
			}else{
				db.AppendRec(code);
			}
			db.Commit();
			MessageBox.Show("添加成功");
            Close();
		}
	}
}
