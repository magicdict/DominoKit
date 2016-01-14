namespace DevKit
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewPrjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenPrjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifyPrjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateModelCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateAllModelCodetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.枚举ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewEnumStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateEnumCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateAllEnumCodetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.NewMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateAllMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateAllCodetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToPrjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.native2ASCIIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.NETMVCRouteEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.struts2路由编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.struts2数据验证ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.代码示例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.使用手册ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.trvProject = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.trvCodeSnippet = new System.Windows.Forms.TreeView();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.ProjectToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(726, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewPrjToolStripMenuItem,
            this.OpenPrjToolStripMenuItem,
            this.ModifyPrjToolStripMenuItem,
            this.toolStripMenuItem1,
            this.CloseToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // NewPrjToolStripMenuItem
            // 
            this.NewPrjToolStripMenuItem.Name = "NewPrjToolStripMenuItem";
            this.NewPrjToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.NewPrjToolStripMenuItem.Text = "新建工程";
            this.NewPrjToolStripMenuItem.Click += new System.EventHandler(this.NewPrjToolStripMenuItem_Click);
            // 
            // OpenPrjToolStripMenuItem
            // 
            this.OpenPrjToolStripMenuItem.Name = "OpenPrjToolStripMenuItem";
            this.OpenPrjToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.OpenPrjToolStripMenuItem.Text = "打开工程";
            this.OpenPrjToolStripMenuItem.Click += new System.EventHandler(this.OpenPrjToolStripMenuItem_Click);
            // 
            // ModifyPrjToolStripMenuItem
            // 
            this.ModifyPrjToolStripMenuItem.Name = "ModifyPrjToolStripMenuItem";
            this.ModifyPrjToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ModifyPrjToolStripMenuItem.Text = "修改工程";
            this.ModifyPrjToolStripMenuItem.Click += new System.EventHandler(this.ModifyPrjToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.CloseToolStripMenuItem.Text = "关闭";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // ProjectToolStripMenuItem
            // 
            this.ProjectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.模型ToolStripMenuItem,
            this.枚举ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.GenerateAllCodetoolStripMenuItem,
            this.ExportToPrjToolStripMenuItem,
            this.toolStripSeparator1,
            this.RefreshToolStripMenuItem});
            this.ProjectToolStripMenuItem.Name = "ProjectToolStripMenuItem";
            this.ProjectToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.ProjectToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.ProjectToolStripMenuItem.Text = "数据定义";
            // 
            // 模型ToolStripMenuItem
            // 
            this.模型ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewModelToolStripMenuItem,
            this.GenerateModelCodeToolStripMenuItem,
            this.GenerateAllModelCodetoolStripMenuItem});
            this.模型ToolStripMenuItem.Name = "模型ToolStripMenuItem";
            this.模型ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.模型ToolStripMenuItem.Text = "模型";
            // 
            // NewModelToolStripMenuItem
            // 
            this.NewModelToolStripMenuItem.Name = "NewModelToolStripMenuItem";
            this.NewModelToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.NewModelToolStripMenuItem.Text = "新建";
            this.NewModelToolStripMenuItem.Click += new System.EventHandler(this.NewModelToolStripMenuItem_Click);
            // 
            // GenerateModelCodeToolStripMenuItem
            // 
            this.GenerateModelCodeToolStripMenuItem.Name = "GenerateModelCodeToolStripMenuItem";
            this.GenerateModelCodeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.GenerateModelCodeToolStripMenuItem.Text = "生成代码";
            this.GenerateModelCodeToolStripMenuItem.Click += new System.EventHandler(this.GenerateModelCodeToolStripMenuItem_Click);
            // 
            // GenerateAllModelCodetoolStripMenuItem
            // 
            this.GenerateAllModelCodetoolStripMenuItem.Name = "GenerateAllModelCodetoolStripMenuItem";
            this.GenerateAllModelCodetoolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.GenerateAllModelCodetoolStripMenuItem.Text = "生成所有代码";
            this.GenerateAllModelCodetoolStripMenuItem.Click += new System.EventHandler(this.GenerateAllModelCodeToolStripMenuItem_Click);
            // 
            // 枚举ToolStripMenuItem
            // 
            this.枚举ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewEnumStripMenuItem,
            this.GenerateEnumCodeToolStripMenuItem,
            this.GenerateAllEnumCodetoolStripMenuItem});
            this.枚举ToolStripMenuItem.Name = "枚举ToolStripMenuItem";
            this.枚举ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.枚举ToolStripMenuItem.Text = "枚举";
            // 
            // NewEnumStripMenuItem
            // 
            this.NewEnumStripMenuItem.Name = "NewEnumStripMenuItem";
            this.NewEnumStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.NewEnumStripMenuItem.Text = "新建";
            this.NewEnumStripMenuItem.Click += new System.EventHandler(this.NewEnumStripMenuItem_Click);
            // 
            // GenerateEnumCodeToolStripMenuItem
            // 
            this.GenerateEnumCodeToolStripMenuItem.Name = "GenerateEnumCodeToolStripMenuItem";
            this.GenerateEnumCodeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.GenerateEnumCodeToolStripMenuItem.Text = "生成代码";
            this.GenerateEnumCodeToolStripMenuItem.Click += new System.EventHandler(this.GenerateEnumCodeToolStripMenuItem_Click);
            // 
            // GenerateAllEnumCodetoolStripMenuItem
            // 
            this.GenerateAllEnumCodetoolStripMenuItem.Name = "GenerateAllEnumCodetoolStripMenuItem";
            this.GenerateAllEnumCodetoolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.GenerateAllEnumCodetoolStripMenuItem.Text = "生成所有代码";
            this.GenerateAllEnumCodetoolStripMenuItem.Click += new System.EventHandler(this.GenerateAllEnumCodetoolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMasterToolStripMenuItem,
            this.GenerateMasterToolStripMenuItem,
            this.GenerateAllMasterToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem2.Text = "辅助表";
            // 
            // NewMasterToolStripMenuItem
            // 
            this.NewMasterToolStripMenuItem.Name = "NewMasterToolStripMenuItem";
            this.NewMasterToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.NewMasterToolStripMenuItem.Text = "新建";
            this.NewMasterToolStripMenuItem.Click += new System.EventHandler(this.NewMasterToolStripMenuItem_Click);
            // 
            // GenerateMasterToolStripMenuItem
            // 
            this.GenerateMasterToolStripMenuItem.Name = "GenerateMasterToolStripMenuItem";
            this.GenerateMasterToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.GenerateMasterToolStripMenuItem.Text = "生成代码";
            this.GenerateMasterToolStripMenuItem.Click += new System.EventHandler(this.GenerateMasterToolStripMenuItem_Click);
            // 
            // GenerateAllMasterToolStripMenuItem
            // 
            this.GenerateAllMasterToolStripMenuItem.Name = "GenerateAllMasterToolStripMenuItem";
            this.GenerateAllMasterToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.GenerateAllMasterToolStripMenuItem.Text = "生成所有代码";
            this.GenerateAllMasterToolStripMenuItem.Click += new System.EventHandler(this.GenerateAllMasterToolStripMenuItem_Click);
            // 
            // GenerateAllCodetoolStripMenuItem
            // 
            this.GenerateAllCodetoolStripMenuItem.Name = "GenerateAllCodetoolStripMenuItem";
            this.GenerateAllCodetoolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.GenerateAllCodetoolStripMenuItem.Text = "生成所有代码";
            this.GenerateAllCodetoolStripMenuItem.Click += new System.EventHandler(this.GenerateAllCodetoolStripMenuItem_Click);
            // 
            // ExportToPrjToolStripMenuItem
            // 
            this.ExportToPrjToolStripMenuItem.Name = "ExportToPrjToolStripMenuItem";
            this.ExportToPrjToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.ExportToPrjToolStripMenuItem.Text = "导出到MVC项目";
            this.ExportToPrjToolStripMenuItem.Click += new System.EventHandler(this.ExportToPrjToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.RefreshToolStripMenuItem.Text = "刷新";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.native2ASCIIToolStripMenuItem,
            this.toolStripMenuItem3,
            this.NETMVCRouteEditorToolStripMenuItem,
            this.struts2路由编辑ToolStripMenuItem,
            this.struts2数据验证ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.代码示例ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // native2ASCIIToolStripMenuItem
            // 
            this.native2ASCIIToolStripMenuItem.Name = "native2ASCIIToolStripMenuItem";
            this.native2ASCIIToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.native2ASCIIToolStripMenuItem.Text = "Native2ASCII";
            this.native2ASCIIToolStripMenuItem.Click += new System.EventHandler(this.native2ASCIIToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(184, 6);
            // 
            // NETMVCRouteEditorToolStripMenuItem
            // 
            this.NETMVCRouteEditorToolStripMenuItem.Name = "NETMVCRouteEditorToolStripMenuItem";
            this.NETMVCRouteEditorToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.NETMVCRouteEditorToolStripMenuItem.Text = ".NET MVC 路由编辑";
            this.NETMVCRouteEditorToolStripMenuItem.Click += new System.EventHandler(this.NETMVCRouteEditorToolStripMenuItem_Click);
            // 
            // struts2路由编辑ToolStripMenuItem
            // 
            this.struts2路由编辑ToolStripMenuItem.Name = "struts2路由编辑ToolStripMenuItem";
            this.struts2路由编辑ToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.struts2路由编辑ToolStripMenuItem.Text = "Struts2 路由编辑";
            this.struts2路由编辑ToolStripMenuItem.Click += new System.EventHandler(this.struts2路由编辑ToolStripMenuItem_Click);
            // 
            // struts2数据验证ToolStripMenuItem
            // 
            this.struts2数据验证ToolStripMenuItem.Name = "struts2数据验证ToolStripMenuItem";
            this.struts2数据验证ToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.struts2数据验证ToolStripMenuItem.Text = "Struts2 数据验证";
            this.struts2数据验证ToolStripMenuItem.Click += new System.EventHandler(this.struts2数据验证ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(184, 6);
            // 
            // 代码示例ToolStripMenuItem
            // 
            this.代码示例ToolStripMenuItem.Name = "代码示例ToolStripMenuItem";
            this.代码示例ToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.代码示例ToolStripMenuItem.Text = "代码示例";
            this.代码示例ToolStripMenuItem.Click += new System.EventHandler(this.代码示例ToolStripMenuItemClick);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.使用手册ToolStripMenuItem,
            this.toolStripSeparator2,
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 使用手册ToolStripMenuItem
            // 
            this.使用手册ToolStripMenuItem.Name = "使用手册ToolStripMenuItem";
            this.使用手册ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.使用手册ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.使用手册ToolStripMenuItem.Text = "使用手册";
            this.使用手册ToolStripMenuItem.Click += new System.EventHandler(this.使用手册ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(142, 6);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 414);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(726, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(726, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtSource);
            this.splitContainer1.Size = new System.Drawing.Size(726, 364);
            this.splitContainer1.SplitterDistance = 242;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(242, 364);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.trvProject);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(234, 338);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "工程";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // trvProject
            // 
            this.trvProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvProject.Location = new System.Drawing.Point(3, 3);
            this.trvProject.Name = "trvProject";
            this.trvProject.Size = new System.Drawing.Size(228, 332);
            this.trvProject.TabIndex = 0;
            this.trvProject.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OpenNode);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.trvCodeSnippet);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(234, 338);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "代码片断";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // trvCodeSnippet
            // 
            this.trvCodeSnippet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvCodeSnippet.Location = new System.Drawing.Point(3, 3);
            this.trvCodeSnippet.Name = "trvCodeSnippet";
            this.trvCodeSnippet.Size = new System.Drawing.Size(228, 332);
            this.trvCodeSnippet.TabIndex = 0;
            this.trvCodeSnippet.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OpenNode);
            // 
            // txtSource
            // 
            this.txtSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSource.Location = new System.Drawing.Point(0, 0);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(480, 364);
            this.txtSource.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(726, 436);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "MVC辅助工具 - 中和软件";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewPrjToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenPrjToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.TreeView trvProject;
        private System.Windows.Forms.ToolStripMenuItem ProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.ToolStripMenuItem 使用手册ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem native2ASCIIToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem NETMVCRouteEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem struts2路由编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem 代码示例ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView trvCodeSnippet;
        private System.Windows.Forms.ToolStripMenuItem GenerateAllCodetoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExportToPrjToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GenerateModelCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GenerateAllModelCodetoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 枚举ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewEnumStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GenerateEnumCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GenerateAllEnumCodetoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem NewMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GenerateMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GenerateAllMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem struts2数据验证ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ModifyPrjToolStripMenuItem;
    }
}

