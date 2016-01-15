using System;
using System.Windows.Forms;

namespace UpgradeMVC5ToMVC6
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// MVC5 WebWSite Root
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMVC5Root_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog mvc5Root = new FolderBrowserDialog();
            if (mvc5Root.ShowDialog() == DialogResult.OK) {
                txtMVC5Root.Text = mvc5Root.SelectedPath;
            }
        }

        /// <summary>
        /// MVC6 WebSite Root
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMVC6Root_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog mvc6Root = new FolderBrowserDialog();
            if (mvc6Root.ShowDialog() == DialogResult.OK)
            {
                txtMVC6Root.Text = mvc6Root.SelectedPath;
            }
        }
        /// <summary>
        ///     Start To Upgrade MVC5 to MVC6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            //TEST
            txtMVC5Root.Text = @"E:\WorkSpace\Domino\WebSite";
            txtMVC6Root.Text = @"E:\WorkSpace\Domino2\src\Domino2";

            SystemManager.mvc5Root = txtMVC5Root.Text;
            SystemManager.mvc6Root = txtMVC6Root.Text;
            //Init
            SystemManager.Init();
            //Analyze The Folder
            StructureAnalyze.Analyze();
            //Upgrade
            MainUpgrade.Upgrade();
            //Terminte
            SystemManager.Terminate();
        }
    }
}
