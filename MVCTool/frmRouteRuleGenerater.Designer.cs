namespace DevKit.MVCTool
{
    partial class frmRouteRuleGenerater
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRouteRuleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSegmentName = new System.Windows.Forms.TextBox();
            this.chkVarRoute = new System.Windows.Forms.CheckBox();
            this.chkOptionRoute = new System.Windows.Forms.CheckBox();
            this.lstRouteRules = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddSegment = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "路由规则名：";
            // 
            // txtRouteRuleName
            // 
            this.txtRouteRuleName.Location = new System.Drawing.Point(103, 11);
            this.txtRouteRuleName.Name = "txtRouteRuleName";
            this.txtRouteRuleName.Size = new System.Drawing.Size(148, 21);
            this.txtRouteRuleName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "名称：";
            // 
            // txtSegmentName
            // 
            this.txtSegmentName.Location = new System.Drawing.Point(90, 14);
            this.txtSegmentName.Name = "txtSegmentName";
            this.txtSegmentName.Size = new System.Drawing.Size(148, 21);
            this.txtSegmentName.TabIndex = 4;
            // 
            // chkVarRoute
            // 
            this.chkVarRoute.AutoSize = true;
            this.chkVarRoute.Location = new System.Drawing.Point(257, 13);
            this.chkVarRoute.Name = "chkVarRoute";
            this.chkVarRoute.Size = new System.Drawing.Size(48, 16);
            this.chkVarRoute.TabIndex = 5;
            this.chkVarRoute.Text = "变量";
            this.chkVarRoute.UseVisualStyleBackColor = true;
            // 
            // chkOptionRoute
            // 
            this.chkOptionRoute.AutoSize = true;
            this.chkOptionRoute.Location = new System.Drawing.Point(310, 14);
            this.chkOptionRoute.Name = "chkOptionRoute";
            this.chkOptionRoute.Size = new System.Drawing.Size(60, 16);
            this.chkOptionRoute.TabIndex = 5;
            this.chkOptionRoute.Text = "可省略";
            this.chkOptionRoute.UseVisualStyleBackColor = true;
            // 
            // lstRouteRules
            // 
            this.lstRouteRules.FullRowSelect = true;
            this.lstRouteRules.GridLines = true;
            this.lstRouteRules.Location = new System.Drawing.Point(22, 164);
            this.lstRouteRules.Name = "lstRouteRules";
            this.lstRouteRules.Size = new System.Drawing.Size(356, 141);
            this.lstRouteRules.TabIndex = 6;
            this.lstRouteRules.UseCompatibleStateImageBehavior = false;
            this.lstRouteRules.View = System.Windows.Forms.View.Details;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 21);
            this.textBox1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "默认值：";
            // 
            // btnAddSegment
            // 
            this.btnAddSegment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddSegment.Location = new System.Drawing.Point(257, 39);
            this.btnAddSegment.Name = "btnAddSegment";
            this.btnAddSegment.Size = new System.Drawing.Size(108, 23);
            this.btnAddSegment.TabIndex = 9;
            this.btnAddSegment.Text = "添加/更新";
            this.btnAddSegment.UseVisualStyleBackColor = false;
            this.btnAddSegment.Click += new System.EventHandler(this.btnAddSegment_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.Location = new System.Drawing.Point(211, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOK.Location = new System.Drawing.Point(73, 320);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(103, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 110);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 16);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "自定义url";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(103, 105);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(289, 21);
            this.textBox2.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(347, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "使用自定义url的时候，默认值的添加还是需要填写路由段信息的";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSegmentName);
            this.groupBox1.Controls.Add(this.chkVarRoute);
            this.groupBox1.Controls.Add(this.chkOptionRoute);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnAddSegment);
            this.groupBox1.Location = new System.Drawing.Point(13, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 69);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "路由片断";
            // 
            // frmRouteRuleGenerater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(403, 359);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstRouteRules);
            this.Controls.Add(this.txtRouteRuleName);
            this.Controls.Add(this.label1);
            this.Name = "frmRouteRuleGenerater";
            this.Text = "路由规则生成";
            this.Load += new System.EventHandler(this.frmRouteRuleGenerater_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRouteRuleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSegmentName;
        private System.Windows.Forms.CheckBox chkVarRoute;
        private System.Windows.Forms.CheckBox chkOptionRoute;
        private System.Windows.Forms.ListView lstRouteRules;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddSegment;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}