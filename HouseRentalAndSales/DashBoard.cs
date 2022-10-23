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
    public partial class DashBoard : UserControl
    {
        DAL h;
        string totCustomers, totOwners, totProperty, Available, sold, revenue;
        public DashBoard()
        {
            InitializeComponent();
            h = new DAL();
            getDashInfo();
        }
        public void getDashInfo()
        {
            totCustomers = h.countAllCustomers();
            lbCust.Text = totCustomers;
            totOwners = h.countAllOwners();
            lbOwner.Text = totOwners;
            totProperty = h.countAllProperties();
            lbTotalProp.Text = totProperty;
            Available = h.countAvailableProperties();
            lbAvail.Text = Available;
            sold = h.countSoldProperties();
            lbSold.Text = sold;
            revenue = h.calculateRevenue();
            lbRevenue.Text = revenue;
        }
    }
}
