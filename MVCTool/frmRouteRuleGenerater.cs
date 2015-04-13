using System;
using System.Windows.Forms;

namespace DevKit.MVCTool
{
    public partial class frmRouteRuleGenerater : Form
    {
        public frmRouteRuleGenerater()
        {
            InitializeComponent();
        }

        private void frmRouteRuleGenerater_Load(object sender, EventArgs e)
        {
            lstRouteRules.Clear();
            lstRouteRules.Columns.Add("段名");
            lstRouteRules.Columns.Add("变量");
            lstRouteRules.Columns.Add("可省略");
            lstRouteRules.Columns.Add("默认值");
        }

        private void btnAddSegment_Click(object sender, EventArgs e)
        {

        }
    }
}
