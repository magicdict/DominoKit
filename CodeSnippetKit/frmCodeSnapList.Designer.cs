/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2014/12/30
 * Time: 13:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DevKit.CodeSnippetMgr
{
	partial class frmCodeSnapList
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox txtCode;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.ListView lstCodeTitle;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.ComboBox cmbCatalog;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtKeyword;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtCode = new System.Windows.Forms.TextBox();
			this.btnCopy = new System.Windows.Forms.Button();
			this.lstCodeTitle = new System.Windows.Forms.ListView();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.cmbCatalog = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnSearch = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtKeyword = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtCode
			// 
			this.txtCode.BackColor = System.Drawing.Color.White;
			this.txtCode.Location = new System.Drawing.Point(12, 308);
			this.txtCode.Multiline = true;
			this.txtCode.Name = "txtCode";
			this.txtCode.ReadOnly = true;
			this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtCode.Size = new System.Drawing.Size(602, 134);
			this.txtCode.TabIndex = 2;
			// 
			// btnCopy
			// 
			this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnCopy.Location = new System.Drawing.Point(525, 465);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(89, 23);
			this.btnCopy.TabIndex = 3;
			this.btnCopy.Text = "复制代码";
			this.btnCopy.UseVisualStyleBackColor = false;
			this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
			// 
			// lstCodeTitle
			// 
			this.lstCodeTitle.FullRowSelect = true;
			this.lstCodeTitle.GridLines = true;
			this.lstCodeTitle.Location = new System.Drawing.Point(12, 55);
			this.lstCodeTitle.Name = "lstCodeTitle";
			this.lstCodeTitle.Size = new System.Drawing.Size(602, 217);
			this.lstCodeTitle.TabIndex = 4;
			this.lstCodeTitle.UseCompatibleStateImageBehavior = false;
			this.lstCodeTitle.View = System.Windows.Forms.View.Details;
			this.lstCodeTitle.SelectedIndexChanged += new System.EventHandler(this.LstCodeTitleSelectedIndexChanged);
			this.lstCodeTitle.DoubleClick += new System.EventHandler(this.BtnEditClick);
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btnDelete.Location = new System.Drawing.Point(525, 279);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "删除示例";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
			// 
			// btnEdit
			// 
			this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnEdit.Location = new System.Drawing.Point(444, 278);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 5;
			this.btnEdit.Text = "编辑示例";
			this.btnEdit.UseVisualStyleBackColor = false;
			this.btnEdit.Click += new System.EventHandler(this.BtnEditClick);
			// 
			// cmbCatalog
			// 
			this.cmbCatalog.FormattingEnabled = true;
			this.cmbCatalog.Location = new System.Drawing.Point(87, 26);
			this.cmbCatalog.Name = "cmbCatalog";
			this.cmbCatalog.Size = new System.Drawing.Size(121, 20);
			this.cmbCatalog.TabIndex = 8;
			this.cmbCatalog.SelectedIndexChanged += new System.EventHandler(this.CmbCatalogSelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(12, 29);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(69, 23);
			this.label5.TabIndex = 7;
			this.label5.Text = "分类";
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnAdd.Location = new System.Drawing.Point(363, 278);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 5;
			this.btnAdd.Text = "添加示例";
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
			// 
			// btnSearch
			// 
			this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnSearch.Location = new System.Drawing.Point(539, 23);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 9;
			this.btnSearch.Text = "检索";
			this.btnSearch.UseVisualStyleBackColor = false;
			this.btnSearch.Click += new System.EventHandler(this.BtnSearchClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(233, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 10;
			this.label1.Text = "关键字：";
			// 
			// txtKeyword
			// 
			this.txtKeyword.Location = new System.Drawing.Point(300, 23);
			this.txtKeyword.Name = "txtKeyword";
			this.txtKeyword.Size = new System.Drawing.Size(219, 21);
			this.txtKeyword.TabIndex = 11;
			// 
			// frmCodeSnapList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(626, 513);
			this.Controls.Add(this.txtKeyword);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.cmbCatalog);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.lstCodeTitle);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.txtCode);
			this.Name = "frmCodeSnapList";
			this.Text = "代码片断";
			this.Load += new System.EventHandler(this.FrmCodeSnapListLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
