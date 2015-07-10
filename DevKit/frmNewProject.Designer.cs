namespace DevKit.MVCTool
{
    partial class frmNewProject
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
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrjPath = new System.Windows.Forms.TextBox();
            this.btnPrjPath = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radJavaStruts2 = new System.Windows.Forms.RadioButton();
            this.radJavaSpring = new System.Windows.Forms.RadioButton();
            this.radCSharpMVC5 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radMsSql = new System.Windows.Forms.RadioButton();
            this.radOracle = new System.Windows.Forms.RadioButton();
            this.radMongo = new System.Windows.Forms.RadioButton();
            this.radMySql = new System.Windows.Forms.RadioButton();
            this.txtPrjRootPath = new System.Windows.Forms.TextBox();
            this.btnPrjRootPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(126, 6);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(268, 21);
            this.txtProjectName.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "项目名称：";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(126, 37);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(268, 21);
            this.txtNameSpace.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "命名空间/Package：";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOK.Location = new System.Drawing.Point(212, 249);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.TabIndex = 21;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "工具保存根目录：";
            // 
            // txtPrjPath
            // 
            this.txtPrjPath.Location = new System.Drawing.Point(126, 103);
            this.txtPrjPath.Name = "txtPrjPath";
            this.txtPrjPath.Size = new System.Drawing.Size(270, 21);
            this.txtPrjPath.TabIndex = 20;
            // 
            // btnPrjPath
            // 
            this.btnPrjPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPrjPath.Location = new System.Drawing.Point(400, 104);
            this.btnPrjPath.Name = "btnPrjPath";
            this.btnPrjPath.Size = new System.Drawing.Size(75, 23);
            this.btnPrjPath.TabIndex = 21;
            this.btnPrjPath.Text = "浏览";
            this.btnPrjPath.UseVisualStyleBackColor = false;
            this.btnPrjPath.Click += new System.EventHandler(this.btnPrjPath_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radJavaStruts2);
            this.groupBox3.Controls.Add(this.radJavaSpring);
            this.groupBox3.Controls.Add(this.radCSharpMVC5);
            this.groupBox3.Location = new System.Drawing.Point(14, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(390, 46);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "开发框架";
            // 
            // radJavaStruts2
            // 
            this.radJavaStruts2.AutoSize = true;
            this.radJavaStruts2.Location = new System.Drawing.Point(232, 20);
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
            this.radJavaSpring.Location = new System.Drawing.Point(89, 20);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radMsSql);
            this.groupBox1.Controls.Add(this.radOracle);
            this.groupBox1.Controls.Add(this.radMongo);
            this.groupBox1.Controls.Add(this.radMySql);
            this.groupBox1.Location = new System.Drawing.Point(14, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 46);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库";
            // 
            // radMsSql
            // 
            this.radMsSql.AutoSize = true;
            this.radMsSql.Location = new System.Drawing.Point(161, 20);
            this.radMsSql.Name = "radMsSql";
            this.radMsSql.Size = new System.Drawing.Size(53, 16);
            this.radMsSql.TabIndex = 2;
            this.radMsSql.Text = "MSSql";
            this.radMsSql.UseVisualStyleBackColor = true;
            // 
            // radOracle
            // 
            this.radOracle.AutoSize = true;
            this.radOracle.Location = new System.Drawing.Point(89, 20);
            this.radOracle.Name = "radOracle";
            this.radOracle.Size = new System.Drawing.Size(59, 16);
            this.radOracle.TabIndex = 1;
            this.radOracle.Text = "Oracle";
            this.radOracle.UseVisualStyleBackColor = true;
            // 
            // radMongo
            // 
            this.radMongo.AutoSize = true;
            this.radMongo.Location = new System.Drawing.Point(232, 20);
            this.radMongo.Name = "radMongo";
            this.radMongo.Size = new System.Drawing.Size(65, 16);
            this.radMongo.TabIndex = 0;
            this.radMongo.Text = "MongoDB";
            this.radMongo.UseVisualStyleBackColor = true;
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
            // txtPrjRootPath
            // 
            this.txtPrjRootPath.Location = new System.Drawing.Point(126, 70);
            this.txtPrjRootPath.Name = "txtPrjRootPath";
            this.txtPrjRootPath.Size = new System.Drawing.Size(268, 21);
            this.txtPrjRootPath.TabIndex = 20;
            // 
            // btnPrjRootPath
            // 
            this.btnPrjRootPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPrjRootPath.Location = new System.Drawing.Point(400, 71);
            this.btnPrjRootPath.Name = "btnPrjRootPath";
            this.btnPrjRootPath.Size = new System.Drawing.Size(75, 23);
            this.btnPrjRootPath.TabIndex = 21;
            this.btnPrjRootPath.Text = "浏览";
            this.btnPrjRootPath.UseVisualStyleBackColor = false;
            this.btnPrjRootPath.Click += new System.EventHandler(this.btnPrjRootPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "实际项目根目录：";
            // 
            // frmNewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(497, 287);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrjRootPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPrjPath);
            this.Controls.Add(this.txtPrjRootPath);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPrjPath);
            this.Controls.Add(this.txtNameSpace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.label5);
            this.Name = "frmNewProject";
            this.Text = "新建工程";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrjPath;
        private System.Windows.Forms.Button btnPrjPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radJavaStruts2;
        private System.Windows.Forms.RadioButton radJavaSpring;
        private System.Windows.Forms.RadioButton radCSharpMVC5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radMsSql;
        private System.Windows.Forms.RadioButton radOracle;
        private System.Windows.Forms.RadioButton radMySql;
        private System.Windows.Forms.RadioButton radMongo;
        private System.Windows.Forms.TextBox txtPrjRootPath;
        private System.Windows.Forms.Button btnPrjRootPath;
        private System.Windows.Forms.Label label3;
    }
}