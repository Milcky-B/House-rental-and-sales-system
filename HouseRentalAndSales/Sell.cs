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
    public partial class Sell : UserControl
    {
        Handle h1;
        public Sell()
        {
            h1 = new Handle();
            InitializeComponent();
            getData();
        }

        private void getData()
        {
            int value = 1;
            int i = 0;
            DataTable dt;
            string spName;
            while (value <= 3)
            {
                if (value == 1)
                {
                    spName = "sendCustID";
                    dt = h1.getID(spName);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmbCust.Items.Insert(i, dr["CustID"].ToString());
                        i += 1;
                    }
                }
                else if (value == 2)
                {
                    i = 0;
                    spName = "sendOwnID";
                    dt = h1.getID(spName);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmbOwn.Items.Insert(i, dr["OwnID"].ToString());
                        i += 1;
                    }
                }

                else if (value == 3)
                {
                    i = 0;
                    spName = "sendPropId";
                    dt = h1.getID(spName);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmbProp.Items.Insert(i, dr["PropId"].ToString());
                        i += 1;
                    }
                }
                value += 1;
            }
        }

        private void clear(ComboBox c)
        {
            c.Text = "";
            MessageBox.Show("Please Select From The Alternatives");
        }
        private void cmbCust_KeyUp(object sender, KeyEventArgs e)
        {
            clear(cmbCust);
        }

        private void cmbOwn_KeyUp(object sender, KeyEventArgs e)
        {
            clear(cmbOwn);
        }

        private void cmbProp_KeyUp(object sender, KeyEventArgs e)
        {
            clear(cmbProp);
        }

        private void cmbSale_KeyUp(object sender, KeyEventArgs e)
        {
            clear(cmbSale);
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbCust.Text=="" || cmbOwn.Text=="" || cmbProp.Text=="" || cmbSale.Text == "")
                {
                    throw new Error("Please Fill All Boxs");
                }
                else
                {
                    h1.insertAudit(int.Parse(cmbCust.Text),int.Parse(cmbOwn.Text), int.Parse(cmbProp.Text), Login.ID, cmbSale.Text);
                }
            }
            catch(Error e1)
            {
                MessageBox.Show(e1.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
