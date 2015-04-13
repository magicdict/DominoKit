namespace DevKit.MVCTool
{
    partial class frmEnumCodeGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.btnDocumentPath = new System.Windows.Forms.Button();
            this.txtDocumentPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSourcePath = new System.Windows.Forms.Button();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.btnGernerateCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "文档路径：";
            // 
            // btnDocumentPath
            // 
            this.btnDocumentPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDocumentPath.Location = new System.Drawing.Point(403, 16);
            this.btnDocumentPath.Name = "btnDocumentPath";
            this.btnDocumentPath.Size = new System.Drawing.Size(75, 23);
            this.btnDocumentPath.TabIndex = 24;
            this.btnDocumentPath.Text = "浏览";
            this.btnDocumentPath.UseVisualStyleBackColor = false;
            this.btnDocumentPath.Click += new System.EventHandler(this.btnDocumentPath_Click);
            // 
            // txtDocumentPath
            // 
            this.txtDocumentPath.Location = new System.Drawing.Point(103, 15);
            this.txtDocumentPath.Name = "txtDocumentPath";
            this.txtDocumentPath.Size = new System.Drawing.Size(294, 21);
            this.txtDocumentPath.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "代码路径：";
            // 
            // btnSourcePath
            // 
            this.btnSourcePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSourcePath.Location = new System.Drawing.Point(403, 46);
            this.btnSourcePath.Name = "btnSourcePath";
            this.btnSourcePath.Size = new System.Drawing.Size(75, 23);
            this.btnSourcePath.TabIndex = 27;
            this.btnSourcePath.Text = "浏览";
            this.btnSourcePath.UseVisualStyleBackColor = false;
            this.btnSourcePath.Click += new System.EventHandler(this.btnSourcePath_Click);
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(103, 45);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(294, 21);
            this.txtSourcePath.TabIndex = 26;
            // 
            // btnGernerateCode
            // 
            this.btnGernerateCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGernerateCode.Location = new System.Drawing.Point(403, 75);
            this.btnGernerateCode.Name = "btnGernerateCode";
            this.btnGernerateCode.Size = new System.Drawing.Size(75, 23);
            this.btnGernerateCode.TabIndex = 29;
            this.btnGernerateCode.Text = "生成";
            this.btnGernerateCode.UseVisualStyleBackColor = false;
            this.btnGernerateCode.Click += new System.EventHandler(this.btnGernerateCode_Click);
            // 
            // frmModelCodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(490, 108);
            this.Controls.Add(this.btnGernerateCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSourcePath);
            this.Controls.Add(this.txtSourcePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDocumentPath);
            this.Controls.Add(this.txtDocumentPath);
            this.Name = "frmModelCodeGenerator";
            this.Text = "模型代码生成工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDocumentPath;
        private System.Windows.Forms.TextBox txtDocumentPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSourcePath;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Button btnGernerateCode;
    }
}