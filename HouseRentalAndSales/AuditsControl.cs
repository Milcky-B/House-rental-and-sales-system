using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseRentalAndSales
{
    public partial class AuditsControl : UserControl
    {
        Handle h1;
        public AuditsControl()
        {
            InitializeComponent();
            h1 = new Handle();
            addAudit();
        }
        private void addAudit()
        {
            dgvAudit.DataSource = h1.getID("sendAudit");
        }

        private void dgvAudit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new ViewAuditDetail(dgvAudit.CurrentRow.Cells[0].Value.ToString(), dgvAudit.CurrentRow.Cells[1].Value.ToString(),
                dgvAudit.CurrentRow.Cells[2].Value.ToString(), dgvAudit.CurrentRow.Cells[3].Value.ToString(),
                dgvAudit.CurrentRow.Cells[4].Value.ToString(), dgvAudit.CurrentRow.Cells[5].Value.ToString()
                ).Visible = true;
        }
    }
}
