namespace DevKit
{
    partial class ModelCodeGenerator
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radJavaStruts2 = new System.Windows.Forms.RadioButton();
            this.radJavaSpring = new System.Windows.Forms.RadioButton();
            this.radCSharpMVC5 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDocumentPath = new System.Windows.Forms.Button();
            this.txtDocumentPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnModelSourcePath = new System.Windows.Forms.Button();
            this.txtModelSourcePath = new System.Windows.Forms.TextBox();
            this.btnGernerateCode = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radMsSql = new System.Windows.Forms.RadioButton();
            this.radOracle = new System.Windows.Forms.RadioButton();
            this.radMySql = new System.Windows.Forms.RadioButton();
            this.chkCreateDDL = new System.Windows.Forms.CheckBox();
            this.txtSqlPath = new System.Windows.Forms.TextBox();
            this.btnSqlPath = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPageSourcePath = new System.Windows.Forms.Button();
            this.txtViewSourcePath = new System.Windows.Forms.TextBox();
            this.chkCreateModel = new System.Windows.Forms.CheckBox();
            this.chkCreateView = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radJavaStruts2);
            this.groupBox3.Controls.Add(this.radJavaSpring);
            this.groupBox3.Controls.Add(this.radCSharpMVC5);
            this.groupBox3.Location = new System.Drawing.Point(118, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(429, 46);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "开发框架";
            // 
            // radJavaStruts2
            // 
            this.radJavaStruts2.AutoSize = true;
            this.radJavaStruts2.Location = new System.Drawing.Point(260, 20);
            this.radJavaStruts2.Name = "radJavaStruts2";
            this.radJavaStruts2.Size = new System.Drawing.Size(107, 16);
            this.radJavaStruts2.TabIndex = 2;
            this.radJavaStruts2.TabStop = true;
            this.radJavaStruts2.Text = "Java - Struts2";
            this.radJavaStruts2.UseVisualStyleBackColor = true;
            // 
            // radJavaSpring
            // 
            this.radJavaSpring.AutoSize = true;
            this.radJavaSpring.Location = new System.Drawing.Point(110, 20);
            this.radJavaSpring.Name = "radJavaSpring";
            this.radJavaSpring.Size = new System.Drawing.Size(125, 16);
            this.radJavaSpring.TabIndex = 1;
            this.radJavaSpring.TabStop = true;
            this.radJavaSpring.Text = "Java - Spring MVC";
            this.radJavaSpring.UseVisualStyleBackColor = true;
            // 
            // radCSharpMVC5
            // 
            this.radCSharpMVC5.AutoSize = true;
            this.radCSharpMVC5.Checked = true;
            this.radCSharpMVC5.Location = new System.Drawing.Point(16, 20);
            this.radCSharpMVC5.Name = "radCSharpMVC5";
            this.radCSharpMVC5.Size = new System.Drawing.Size(65, 16);
            this.radCSharpMVC5.TabIndex = 0;
            this.radCSharpMVC5.TabStop = true;
            this.radCSharpMVC5.Text = "C# MVC5";
            this.radCSharpMVC5.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "文档路径：";
            // 
            // btnDocumentPath
            // 
            this.btnDocumentPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDocumentPath.Location = new System.Drawing.Point(553, 129);
            this.btnDocumentPath.Name = "btnDocumentPath";
            this.btnDocumentPath.Size = new System.Drawing.Size(75, 23);
            this.btnDocumentPath.TabIndex = 24;
            this.btnDocumentPath.Text = "浏览";
            this.btnDocumentPath.UseVisualStyleBackColor = false;
            this.btnDocumentPath.Click += new System.EventHandler(this.btnDocumentPath_Click);
            // 
            // txtDocumentPath
            // 
            this.txtDocumentPath.Location = new System.Drawing.Point(118, 128);
            this.txtDocumentPath.Name = "txtDocumentPath";
            this.txtDocumentPath.Size = new System.Drawing.Size(429, 21);
            this.txtDocumentPath.TabIndex = 23;
            this.txtDocumentPath.Text = "E:\\WorkSpace\\DominoKit\\Generator\\Entity\\Document\\Position.xlsx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "模型代码路径：";
            // 
            // btnModelSourcePath
            // 
            this.btnModelSourcePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnModelSourcePath.Location = new System.Drawing.Point(553, 159);
            this.btnModelSourcePath.Name = "btnModelSourcePath";
            this.btnModelSourcePath.Size = new System.Drawing.Size(75, 23);
            this.btnModelSourcePath.TabIndex = 27;
            this.btnModelSourcePath.Text = "浏览";
            this.btnModelSourcePath.UseVisualStyleBackColor = false;
            this.btnModelSourcePath.Click += new System.EventHandler(this.btnSourcePath_Click);
            // 
            // txtModelSourcePath
            // 
            this.txtModelSourcePath.Location = new System.Drawing.Point(118, 158);
            this.txtModelSourcePath.Name = "txtModelSourcePath";
            this.txtModelSourcePath.Size = new System.Drawing.Size(429, 21);
            this.txtModelSourcePath.TabIndex = 26;
            // 
            // btnGernerateCode
            // 
            this.btnGernerateCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGernerateCode.Location = new System.Drawing.Point(553, 251);
            this.btnGernerateCode.Name = "btnGernerateCode";
            this.btnGernerateCode.Size = new System.Drawing.Size(75, 23);
            this.btnGernerateCode.TabIndex = 29;
            this.btnGernerateCode.Text = "生成";
            this.btnGernerateCode.UseVisualStyleBackColor = false;
            this.btnGernerateCode.Click += new System.EventHandler(this.btnGernerateCode_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radMsSql);
            this.groupBox1.Controls.Add(this.radOracle);
            this.groupBox1.Controls.Add(this.radMySql);
            this.groupBox1.Location = new System.Drawing.Point(118, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 46);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(260, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(65, 16);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "MongoDB";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radMsSql
            // 
            this.radMsSql.AutoSize = true;
            this.radMsSql.Location = new System.Drawing.Point(182, 20);
            this.radMsSql.Name = "radMsSql";
            this.radMsSql.Size = new System.Drawing.Size(53, 16);
            this.radMsSql.TabIndex = 2;
            this.radMsSql.TabStop = true;
            this.radMsSql.Text = "MsSql";
            this.radMsSql.UseVisualStyleBackColor = true;
            // 
            // radOracle
            // 
            this.radOracle.AutoSize = true;
            this.radOracle.Location = new System.Drawing.Point(110, 20);
            this.radOracle.Name = "radOracle";
            this.radOracle.Size = new System.Drawing.Size(59, 16);
            this.radOracle.TabIndex = 1;
            this.radOracle.TabStop = true;
            this.radOracle.Text = "Oracle";
            this.radOracle.UseVisualStyleBackColor = true;
            // 
            // radMySql
            // 
            this.radMySql.AutoSize = true;
            this.radMySql.Checked = true;
            this.radMySql.Location = new System.Drawing.Point(16, 20);
            this.radMySql.Name = "radMySql";
            this.radMySql.Size = new System.Drawing.Size(53, 16);
            this.radMySql.TabIndex = 0;
            this.radMySql.TabStop = true;
            this.radMySql.Text = "MySql";
            this.radMySql.UseVisualStyleBackColor = true;
            // 
            // chkCreateDDL
            // 
            this.chkCreateDDL.AutoSize = true;
            this.chkCreateDDL.Location = new System.Drawing.Point(433, 255);
            this.chkCreateDDL.Name = "chkCreateDDL";
            this.chkCreateDDL.Size = new System.Drawing.Size(102, 16);
            this.chkCreateDDL.TabIndex = 31;
            this.chkCreateDDL.Text = "生成建表Sql文";
            this.chkCreateDDL.UseVisualStyleBackColor = true;
            // 
            // txtSqlPath
            // 
            this.txtSqlPath.Location = new System.Drawing.Point(118, 222);
            this.txtSqlPath.Name = "txtSqlPath";
            this.txtSqlPath.Size = new System.Drawing.Size(427, 21);
            this.txtSqlPath.TabIndex = 26;
            // 
            // btnSqlPath
            // 
            this.btnSqlPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSqlPath.Location = new System.Drawing.Point(553, 223);
            this.btnSqlPath.Name = "btnSqlPath";
            this.btnSqlPath.Size = new System.Drawing.Size(75, 23);
            this.btnSqlPath.TabIndex = 27;
            this.btnSqlPath.Text = "浏览";
            this.btnSqlPath.UseVisualStyleBackColor = false;
            this.btnSqlPath.Click += new System.EventHandler(this.btnSqlPath_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "SQL路径：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(425, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "代码路径可以不填写";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "页面代码路径：";
            // 
            // btnPageSourcePath
            // 
            this.btnPageSourcePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPageSourcePath.Location = new System.Drawing.Point(553, 188);
            this.btnPageSourcePath.Name = "btnPageSourcePath";
            this.btnPageSourcePath.Size = new System.Drawing.Size(75, 23);
            this.btnPageSourcePath.TabIndex = 34;
            this.btnPageSourcePath.Text = "浏览";
            this.btnPageSourcePath.UseVisualStyleBackColor = false;
            this.btnPageSourcePath.Click += new System.EventHandler(this.btnPageSourcePath_Click);
            // 
            // txtPageSourcePath
            // 
            this.txtViewSourcePath.Location = new System.Drawing.Point(118, 187);
            this.txtViewSourcePath.Name = "txtPageSourcePath";
            this.txtViewSourcePath.Size = new System.Drawing.Size(429, 21);
            this.txtViewSourcePath.TabIndex = 33;
            // 
            // chkCreateModel
            // 
            this.chkCreateModel.AutoSize = true;
            this.chkCreateModel.Location = new System.Drawing.Point(325, 255);
            this.chkCreateModel.Name = "chkCreateModel";
            this.chkCreateModel.Size = new System.Drawing.Size(96, 16);
            this.chkCreateModel.TabIndex = 31;
            this.chkCreateModel.Text = "生成数据模型";
            this.chkCreateModel.UseVisualStyleBackColor = true;
            // 
            // chkCreateView
            // 
            this.chkCreateView.AutoSize = true;
            this.chkCreateView.Location = new System.Drawing.Point(217, 255);
            this.chkCreateView.Name = "chkCreateView";
            this.chkCreateView.Size = new System.Drawing.Size(96, 16);
            this.chkCreateView.TabIndex = 31;
            this.chkCreateView.Text = "生成MVC5视图";
            this.chkCreateView.UseVisualStyleBackColor = true;
            // 
            // ModelCodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(655, 302);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPageSourcePath);
            this.Controls.Add(this.txtViewSourcePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkCreateView);
            this.Controls.Add(this.chkCreateModel);
            this.Controls.Add(this.chkCreateDDL);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGernerateCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSqlPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSqlPath);
            this.Controls.Add(this.btnModelSourcePath);
            this.Controls.Add(this.txtModelSourcePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDocumentPath);
            this.Controls.Add(this.txtDocumentPath);
            this.Controls.Add(this.groupBox3);
            this.Name = "ModelCodeGenerator";
            this.Text = "模型代码生成工具";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radJavaSpring;
        private System.Windows.Forms.RadioButton radCSharpMVC5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDocumentPath;
        private System.Windows.Forms.TextBox txtDocumentPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnModelSourcePath;
        private System.Windows.Forms.TextBox txtModelSourcePath;
        private System.Windows.Forms.Button btnGernerateCode;
        private System.Windows.Forms.RadioButton radJavaStruts2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radMsSql;
        private System.Windows.Forms.RadioButton radOracle;
        private System.Windows.Forms.RadioButton radMySql;
        private System.Windows.Forms.CheckBox chkCreateDDL;
        private System.Windows.Forms.TextBox txtSqlPath;
        private System.Windows.Forms.Button btnSqlPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPageSourcePath;
        private System.Windows.Forms.TextBox txtViewSourcePath;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox chkCreateModel;
        private System.Windows.Forms.CheckBox chkCreateView;
    }
}