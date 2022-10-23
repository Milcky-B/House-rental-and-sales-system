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
    public partial class ViewAuditDetail : Form
    {
        public ViewAuditDetail(string custID,string ownID,string propID,string type,string empID,string date)
        {
            InitializeComponent();
            txtCust.Text = custID;
            txtOwner.Text = ownID;
            txtProp.Text = propID;
            txtType.Text = type;
            txtEmp.Text = empID;
            txtDate.Text = date;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
