using System;
using System.Windows.Forms;

namespace DevKit.MVCTool
{
    public partial class frmNewProject : Form
    {
        private ProjectInfo _proj;
        /// <summary>
        /// 
        /// </summary>
        public frmNewProject(ProjectInfo proj)
        {
            InitializeComponent();
            _proj = proj;
            if (!string.IsNullOrEmpty(_proj.Name))
            {
                txtProjectName.Text = _proj.Name;
                txtNameSpace.Text = _proj.NameSpace;
                txtPrjPath.Text = _proj.PrjToolPath;
                txtPrjRootPath.Text = _proj.PrjRootPath;
                switch (_proj.DevFramework)
                {
                    case Common.CSharp.strCSharpMVC5:
                        radCSharpMVC5.Checked = true;
                        break;
                    case Common.Java.strJavaSpring:
                        radJavaSpring.Checked = true;
                        break;
                    case Common.Java.strJavaStruts2:
                        radJavaStruts2.Checked = true;
                        break;
                    default:
                        break;
                }
                switch (_proj.DataBaseType)
                {
                    case DevKit.Common.EnumAndConst.DataBase.MySql:
                        radMySql.Checked = true;
                        break;
                    case DevKit.Common.EnumAndConst.DataBase.Oracle:
                        radOracle.Checked = true;
                        break;
                    case DevKit.Common.EnumAndConst.DataBase.MSSql:
                        radMsSql.Checked = true;
                        break;
                    case DevKit.Common.EnumAndConst.DataBase.MongoDB:
                        radMongo.Checked = true;
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            _proj.Name = txtProjectName.Text;
            _proj.NameSpace = txtNameSpace.Text;
            _proj.PrjToolPath = txtPrjPath.Text;
            _proj.PrjRootPath = txtPrjRootPath.Text;
            //语言和框架
            if (radCSharpMVC5.Checked)
            {
                _proj.DevFramework = Common.CSharp.strCSharpMVC5;
                _proj.DevLanguage = Common.EnumAndConst.Language.CSharp;
            }
            if (radJavaSpring.Checked)
            {
                _proj.DevFramework = Common.Java.strJavaSpring;
                _proj.DevLanguage = Common.EnumAndConst.Language.Java;
            }
            if (radJavaStruts2.Checked)
            {
                _proj.DevFramework = Common.Java.strJavaStruts2;
                _proj.DevLanguage = Common.EnumAndConst.Language.Java;
            }
            //数据库
            if (radMySql.Checked) _proj.DataBaseType = Common.EnumAndConst.DataBase.MySql;
            if (radOracle.Checked) _proj.DataBaseType = Common.EnumAndConst.DataBase.Oracle;
            if (radMsSql.Checked) _proj.DataBaseType = Common.EnumAndConst.DataBase.MSSql;
            if (radMongo.Checked) _proj.DataBaseType = Common.EnumAndConst.DataBase.MongoDB;

            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrjPath_Click(object sender, EventArgs e)
        {
            txtPrjPath.Text = Common.Utility.PickFolder();
        }

        private void btnPrjRootPath_Click(object sender, EventArgs e)
        {
            txtPrjRootPath.Text = Common.Utility.PickFolder();
        }
    }
}
