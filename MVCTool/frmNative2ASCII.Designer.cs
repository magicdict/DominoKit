namespace DevKit.MVCTool
{
    partial class frmNative2ASCII
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtNative = new System.Windows.Forms.TextBox();
            this.txtASCII = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnBatchConvert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDocumentPath = new System.Windows.Forms.Button();
            this.txtDocumentPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Native";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "ASCII";
            // 
            // txtNative
            // 
            this.txtNative.Location = new System.Drawing.Point(94, 23);
            this.txtNative.Name = "txtNative";
            this.txtNative.Size = new System.Drawing.Size(391, 21);
            this.txtNative.TabIndex = 2;
            // 
            // txtASCII
            // 
            this.txtASCII.Location = new System.Drawing.Point(94, 50);
            this.txtASCII.Name = "txtASCII";
            this.txtASCII.Size = new System.Drawing.Size(391, 21);
            this.txtASCII.TabIndex = 3;
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnConvert.Location = new System.Drawing.Point(403, 77);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(79, 23);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "转换";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnBatchConvert
            // 
            this.btnBatchConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBatchConvert.Location = new System.Drawing.Point(403, 137);
            this.btnBatchConvert.Name = "btnBatchConvert";
            this.btnBatchConvert.Size = new System.Drawing.Size(79, 23);
            this.btnBatchConvert.TabIndex = 4;
            this.btnBatchConvert.Text = "批量转换";
            this.btnBatchConvert.UseVisualStyleBackColor = false;
            this.btnBatchConvert.Click += new System.EventHandler(this.btnBatchConvert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "批量转换：";
            // 
            // btnDocumentPath
            // 
            this.btnDocumentPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDocumentPath.Location = new System.Drawing.Point(403, 108);
            this.btnDocumentPath.Name = "btnDocumentPath";
            this.btnDocumentPath.Size = new System.Drawing.Size(79, 23);
            this.btnDocumentPath.TabIndex = 27;
            this.btnDocumentPath.Text = "浏览";
            this.btnDocumentPath.UseVisualStyleBackColor = false;
            this.btnDocumentPath.Click += new System.EventHandler(this.btnDocumentPath_Click);
            // 
            // txtDocumentPath
            // 
            this.txtDocumentPath.Location = new System.Drawing.Point(94, 107);
            this.txtDocumentPath.Name = "txtDocumentPath";
            this.txtDocumentPath.Size = new System.Drawing.Size(294, 21);
            this.txtDocumentPath.TabIndex = 26;
            // 
            // frmNative2ASCII
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(512, 182);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDocumentPath);
            this.Controls.Add(this.txtDocumentPath);
            this.Controls.Add(this.btnBatchConvert);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtASCII);
            this.Controls.Add(this.txtNative);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmNative2ASCII";
            this.Text = "Native2ASCII";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNative;
        private System.Windows.Forms.TextBox txtASCII;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnBatchConvert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDocumentPath;
        private System.Windows.Forms.TextBox txtDocumentPath;
    }
}