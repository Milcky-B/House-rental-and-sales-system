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
    public partial class ViewData : UserControl
    {
        Handle h1;
        public ViewData()
        {
            InitializeComponent();
            h1 = new Handle();
        }

        private void btnCust_Click(object sender, EventArgs e)
        {
            dgvView.DataSource = h1.getID("sendCustDetail");
        }

        private void btnOwner_Click(object sender, EventArgs e)
        {
            dgvView.DataSource = h1.getID("sendOwner");
        }

        private void btnProperty_Click(object sender, EventArgs e)
        {
            dgvView.DataSource = h1.getID("sendProperty");
        }

        private void btnPictures_Click(object sender, EventArgs e)
        {
            dgvView.DataSource = h1.getID("sendPicture");
        }
    }
}
