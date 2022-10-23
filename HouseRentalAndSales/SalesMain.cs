using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseRentalAndSales
{
    public partial class SalesMain : Form
    {
        private ToolTip t1;
        public SalesMain()
        {
            InitializeComponent();
            RoleLabel.Text = Login.ROLE;
            FullLabel.Text = Login.FULLNAME;
            t1 = new ToolTip();
            checkRole();
        }
        private void checkRole()
        {
            if (Login.ROLE.Equals("Sales"))
            {
                btnAudit.Visible = false;
                btnEmployees.Visible = false;
                btnRemove.Visible = false;
                btnView.Visible = false;
                btnDashboard.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Login.ROLE.Equals("Human Resource"))
            {
                string i;
                i = MessageBox.Show("Do You Want To Backup The Database", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                if (i.CompareTo("Yes") == 0)
                {
                    new Handle().backUp();
                }
            }
            Dispose();
        }

        private void moveSelection(Control btn)
        {
            panel5.Top = btn.Top;
            panel5.Height = btn.Height;
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);
        }
        
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            moveSelection(btnCustomer);
            UserControl1 c = new UserControl1();
            AddControlsToPanel(c);
        }

        private void btnOwner_Click(object sender, EventArgs e)
        {
            moveSelection(btnOwner);
            OwnerControl oc = new OwnerControl();
            AddControlsToPanel(oc);
        }

        private void btnProperty_Click(object sender, EventArgs e)
        {
            moveSelection(btnProperty);
            PropertyUC pc = new PropertyUC();
            AddControlsToPanel(pc);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            moveSelection(btnSearch);
            Search s = new Search();
            AddControlsToPanel(s);
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            moveSelection(btnSell);
            Sell sl = new Sell();
            AddControlsToPanel(sl);
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Logout", button6);
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            moveSelection(btnEmployees);
            Employees emp = new Employees();
            AddControlsToPanel(emp);
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            moveSelection(btnAudit);
            AuditsControl ac = new AuditsControl();
            AddControlsToPanel(ac);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            moveSelection(btnView);
            ViewData vd = new ViewData();
            AddControlsToPanel(vd);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            moveSelection(btnRemove);
            RemoveControl rc = new RemoveControl();
            AddControlsToPanel(rc);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            moveSelection(btnDashboard);
            DashBoard dsh = new DashBoard();
            AddControlsToPanel(dsh);
        }
    }
}
