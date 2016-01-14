namespace UpgradeMVC5ToMVC6
{
    partial class frmMain
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
            this.txtMVC5Root = new System.Windows.Forms.TextBox();
            this.btnMVC5Root = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMVC6Root = new System.Windows.Forms.TextBox();
            this.btnMVC6Root = new System.Windows.Forms.Button();
            this.btnUpgrade = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Root(MVC5)";
            // 
            // txtMVC5Root
            // 
            this.txtMVC5Root.Location = new System.Drawing.Point(90, 27);
            this.txtMVC5Root.Name = "txtMVC5Root";
            this.txtMVC5Root.Size = new System.Drawing.Size(499, 21);
            this.txtMVC5Root.TabIndex = 1;
            // 
            // btnMVC5Root
            // 
            this.btnMVC5Root.Location = new System.Drawing.Point(595, 25);
            this.btnMVC5Root.Name = "btnMVC5Root";
            this.btnMVC5Root.Size = new System.Drawing.Size(75, 23);
            this.btnMVC5Root.TabIndex = 2;
            this.btnMVC5Root.Text = "Browse..";
            this.btnMVC5Root.UseVisualStyleBackColor = true;
            this.btnMVC5Root.Click += new System.EventHandler(this.btnMVC5Root_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Root(MVC6)";
            // 
            // txtMVC6Root
            // 
            this.txtMVC6Root.Location = new System.Drawing.Point(90, 53);
            this.txtMVC6Root.Name = "txtMVC6Root";
            this.txtMVC6Root.Size = new System.Drawing.Size(499, 21);
            this.txtMVC6Root.TabIndex = 3;
            // 
            // btnMVC6Root
            // 
            this.btnMVC6Root.Location = new System.Drawing.Point(595, 53);
            this.btnMVC6Root.Name = "btnMVC6Root";
            this.btnMVC6Root.Size = new System.Drawing.Size(75, 23);
            this.btnMVC6Root.TabIndex = 4;
            this.btnMVC6Root.Text = "Browse..";
            this.btnMVC6Root.UseVisualStyleBackColor = true;
            this.btnMVC6Root.Click += new System.EventHandler(this.btnMVC6Root_Click);
            // 
            // btnUpgrade
            // 
            this.btnUpgrade.Location = new System.Drawing.Point(206, 149);
            this.btnUpgrade.Name = "btnUpgrade";
            this.btnUpgrade.Size = new System.Drawing.Size(264, 34);
            this.btnUpgrade.TabIndex = 5;
            this.btnUpgrade.Text = "Upgrade";
            this.btnUpgrade.UseVisualStyleBackColor = true;
            this.btnUpgrade.Click += new System.EventHandler(this.btnUpgrade_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(335, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "This tool will not modify anything at MVC5 root folder.\r\nA upgrade copy will gene" +
    "rate at MVC6 root folder.";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(685, 212);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUpgrade);
            this.Controls.Add(this.btnMVC6Root);
            this.Controls.Add(this.txtMVC6Root);
            this.Controls.Add(this.btnMVC5Root);
            this.Controls.Add(this.txtMVC5Root);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "Upgrade MVC5 To MVC6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMVC5Root;
        private System.Windows.Forms.Button btnMVC5Root;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMVC6Root;
        private System.Windows.Forms.Button btnMVC6Root;
        private System.Windows.Forms.Button btnUpgrade;
        private System.Windows.Forms.Label label3;
    }
}

