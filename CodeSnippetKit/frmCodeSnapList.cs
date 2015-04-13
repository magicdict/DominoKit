/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2014/12/30
 * Time: 13:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevKit.Common;

namespace DevKit.CodeSnippetMgr
{
	/// <summary>
	/// Description of frmCodeSnap.
	/// </summary>
	public partial class frmCodeSnapList : Form
	{
		/// <summary>
		/// 数据库
		/// </summary>
		XmlDataBase<codeSnippet> db;
		/// <summary>
		/// 数据库文件名称
		/// </summary>
		string _dbfile = string.Empty;
		/// <summary>
		/// 数据列表
		/// </summary>
		List<Model<codeSnippet>> CodeSnapList;
		
		public frmCodeSnapList(string dbfile)
		{
			_dbfile = dbfile;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		/// <summary>
		/// 复制
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void BtnCopyClick(object sender, EventArgs e)
		{
			txtCode.SelectAll();
			txtCode.Copy();
		}
		/// <summary>
		/// 列表选中
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void LstCodeTitleSelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstCodeTitle.SelectedItems.Count == 1) {
				//更新描述和代码
				//注意改行的问题
				string id = lstCodeTitle.SelectedItems[0].Tag.ToString();
				txtCode.Text = CodeSnapList.Find((x) => {
					return x.DBId == id;
				}).DataRec.Code.Replace("\n", System.Environment.NewLine);
			}
		}
		
		/// <summary>
		/// 刷新列表
		/// </summary>
		void RefreshList(Func<codeSnippet,Boolean> method)
		{
			//获取数据
			CodeSnapList = db.SearchAsDBRecord(method);
			//加载数据
			lstCodeTitle.Items.Clear();
			foreach (var element in CodeSnapList) {
				var t = new ListViewItem(element.DataRec.Title);
				t.SubItems.Add(element.DataRec.Descrpition);
				t.SubItems.Add(element.DataRec.Tag);
				t.SubItems.Add(element.DataRec.Catalog);
				t.Tag = element.DBId;
				lstCodeTitle.Items.Add(t);
			}
			//调整宽度
			Utility.ListViewColumnResize(lstCodeTitle);
			//清空文本框
			txtCode.Clear();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void FrmCodeSnapListLoad(object sender, EventArgs e)
		{
			//抽取数据
			db = new Common.XmlDataBase<codeSnippet>(_dbfile);
			//初始化控件
			lstCodeTitle.Clear();
			lstCodeTitle.Columns.Add("主题");
			lstCodeTitle.Columns.Add("描述");
			lstCodeTitle.Columns.Add("标签");
			lstCodeTitle.Columns.Add("分类");
			//这里会触发CmbCatalogSelectedIndexChanged，进而触发数据加载事件
			Utility.FillComberWithArray(cmbCatalog, codeSnippet.strCatalog, false);
		}
		/// <summary>
		/// 分类变更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void CmbCatalogSelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshList((x) => {
				if (cmbCatalog.SelectedIndex == 0) {
					return true;
				} else {
					return x.Catalog == cmbCatalog.Text;
				}
			});
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void BtnDeleteClick(object sender, EventArgs e)
		{
			if (lstCodeTitle.SelectedItems.Count == 1) {
				//更新描述和代码
				string id = lstCodeTitle.SelectedItems[0].Tag.ToString();
				db.DelRecByDBID(id);
				db.Commit();
				RefreshList((x) => {
					return true;
				});
			}
		}
		/// <summary>
		/// 编辑记录
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void BtnEditClick(object sender, EventArgs e)
		{
			if (lstCodeTitle.SelectedItems.Count == 1) {
				string id = lstCodeTitle.SelectedItems[0].Tag.ToString();
				Utility.SetUp(new frmCodeSnapAdd(_dbfile, id));
				RefreshList((x) => {
					return true;
				});
			}
		}
		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void BtnAddClick(object sender, EventArgs e)
		{
			Utility.SetUp(new frmCodeSnapAdd(_dbfile));
			RefreshList((x) => {
				return true;
			});
		}
		/// <summary>
		/// 检索
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void BtnSearchClick(object sender, EventArgs e)
		{
			//检索
			RefreshList(codeSnippet.Search(txtKeyword.Text));
		}
	}
}
