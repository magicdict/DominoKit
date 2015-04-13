namespace DevKit.MVCTool
{
    partial class frmRouteRuleForStruts
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
            this.btnGernerateCode = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSourcePath = new System.Windows.Forms.Button();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDocumentPath = new System.Windows.Forms.Button();
            this.txtDocumentPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPackage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGernerateCode
            // 
            this.btnGernerateCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGernerateCode.Location = new System.Drawing.Point(409, 110);
            this.btnGernerateCode.Name = "btnGernerateCode";
            this.btnGernerateCode.Size = new System.Drawing.Size(75, 23);
            this.btnGernerateCode.TabIndex = 36;
            this.btnGernerateCode.Text = "生成";
            this.btnGernerateCode.UseVisualStyleBackColor = false;
            this.btnGernerateCode.Click += new System.EventHandler(this.btnGernerateCode_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "代码路径：";
            // 
            // btnSourcePath
            // 
            this.btnSourcePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSourcePath.Location = new System.Drawing.Point(409, 53);
            this.btnSourcePath.Name = "btnSourcePath";
            this.btnSourcePath.Size = new System.Drawing.Size(75, 23);
            this.btnSourcePath.TabIndex = 34;
            this.btnSourcePath.Text = "浏览";
            this.btnSourcePath.UseVisualStyleBackColor = false;
            this.btnSourcePath.Click += new System.EventHandler(this.btnSourcePath_Click);
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(109, 52);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(294, 21);
            this.txtSourcePath.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "文档路径：";
            // 
            // btnDocumentPath
            // 
            this.btnDocumentPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDocumentPath.Location = new System.Drawing.Point(409, 23);
            this.btnDocumentPath.Name = "btnDocumentPath";
            this.btnDocumentPath.Size = new System.Drawing.Size(75, 23);
            this.btnDocumentPath.TabIndex = 31;
            this.btnDocumentPath.Text = "浏览";
            this.btnDocumentPath.UseVisualStyleBackColor = false;
            this.btnDocumentPath.Click += new System.EventHandler(this.btnDocumentPath_Click);
            // 
            // txtDocumentPath
            // 
            this.txtDocumentPath.Location = new System.Drawing.Point(109, 22);
            this.txtDocumentPath.Name = "txtDocumentPath";
            this.txtDocumentPath.Size = new System.Drawing.Size(294, 21);
            this.txtDocumentPath.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "Package名称：";
            // 
            // txtPackage
            // 
            this.txtPackage.Location = new System.Drawing.Point(109, 79);
            this.txtPackage.Name = "txtPackage";
            this.txtPackage.Size = new System.Drawing.Size(294, 21);
            this.txtPackage.TabIndex = 33;
            // 
            // frmRouteRuleForStruts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(505, 145);
            this.Controls.Add(this.btnGernerateCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSourcePath);
            this.Controls.Add(this.txtPackage);
            this.Controls.Add(this.txtSourcePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDocumentPath);
            this.Controls.Add(this.txtDocumentPath);
            this.Name = "frmRouteRuleForStruts";
            this.Text = "Struts2路由";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGernerateCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSourcePath;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDocumentPath;
        private System.Windows.Forms.TextBox txtDocumentPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPackage;
    }
}