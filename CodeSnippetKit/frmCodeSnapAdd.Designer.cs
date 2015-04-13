/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2014/12/30
 * Time: 14:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DevKit.CodeSnippetMgr
{
	partial class frmCodeSnapAdd
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtTag;
		private System.Windows.Forms.TextBox txtCode;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnAppend;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbCatalog;
		
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTag = new System.Windows.Forms.TextBox();
			this.txtCode = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnAppend = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbCatalog = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(17, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "代码标题";
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(102, 12);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(254, 21);
			this.txtTitle.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(17, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "代码描述";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(102, 50);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(254, 51);
			this.txtDescription.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(17, 130);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Tag标签";
			// 
			// txtTag
			// 
			this.txtTag.Location = new System.Drawing.Point(102, 132);
			this.txtTag.Name = "txtTag";
			this.txtTag.Size = new System.Drawing.Size(254, 21);
			this.txtTag.TabIndex = 3;
			// 
			// txtCode
			// 
			this.txtCode.Location = new System.Drawing.Point(17, 184);
			this.txtCode.Multiline = true;
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(339, 219);
			this.txtCode.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.Location = new System.Drawing.Point(17, 158);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "代码片断";
			// 
			// btnAppend
			// 
			this.btnAppend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnAppend.Location = new System.Drawing.Point(281, 432);
			this.btnAppend.Name = "btnAppend";
			this.btnAppend.Size = new System.Drawing.Size(75, 23);
			this.btnAppend.TabIndex = 5;
			this.btnAppend.Text = "添加";
			this.btnAppend.UseVisualStyleBackColor = false;
			this.btnAppend.Click += new System.EventHandler(this.BtnAppendClick);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(17, 107);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(69, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "分类";
			// 
			// cmbCatalog
			// 
			this.cmbCatalog.FormattingEnabled = true;
			this.cmbCatalog.Location = new System.Drawing.Point(102, 108);
			this.cmbCatalog.Name = "cmbCatalog";
			this.cmbCatalog.Size = new System.Drawing.Size(121, 20);
			this.cmbCatalog.TabIndex = 2;
			// 
			// frmCodeSnapAdd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(372, 474);
			this.Controls.Add(this.cmbCatalog);
			this.Controls.Add(this.btnAppend);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtCode);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtTag);
			this.Controls.Add(this.txtTitle);
			this.Controls.Add(this.label1);
			this.Name = "frmCodeSnapAdd";
			this.Text = "添加代码片断";
			this.Load += new System.EventHandler(this.FrmCodeManagerLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
