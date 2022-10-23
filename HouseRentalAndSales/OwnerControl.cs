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
    public partial class OwnerControl : UserControl
    {
        private Handle h1;
        public OwnerControl()
        {
            InitializeComponent();
            h1 = new Handle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(searchTxt.Text);
                DataTable dt = h1.getCustomer(i, "sendOwn");
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr.IsNull("OwnFname"))
                    {
                        throw new Error("No Customer Found For By That Id");
                    }
                    else
                    {
                        txtFname.Text = dr["OwnFname"].ToString();
                        txtLname.Text = dr["OwnLname"].ToString();
                        txtID.Text = dr["OwnId"].ToString();
                        txtPhone.Text = dr["OwnPhone"].ToString();
                    }
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Please Enter An ID");
            }
            catch (Error e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void searchTxt_MouseClick(object sender, MouseEventArgs e)
        {
            searchTxt.Text = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnInsert.Enabled = true;
            btnCancel.Enabled = true;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
            txtID.Visible = false;
            searchTxt.Visible = false;
            txtFname.Text = null;
            txtLname.Text = null;
            txtPhone.Text = null;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                bool contain = txtFname.Text.Any(char.IsDigit);
                bool contains = txtLname.Text.Any(char.IsDigit);
                if (txtFname.Text == "" || txtLname.Text == ""  || txtPhone.Text == "")
                {
                    throw new Error("Please Make Sure All Data Is Entered");
                }
                else if(contain || contains)
                {
                    throw new Error("Please Enter A Valid Name");
                }
                else
                {
                    searchTxt.Text = h1.insertCust(txtFname.Text, txtLname.Text, txtPhone.Text, "insertOwner");
                    btnInsert.Enabled = false;
                    btnCancel.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnAdd.Enabled = true;
                    txtID.Visible = true;
                    searchTxt.Visible = true;
                    button1.PerformClick();
                }
            }
            catch (Error e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnInsert.Enabled = false;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = true;
            btnAdd.Enabled = true;
            txtID.Visible = true;
            searchTxt.Visible = true;
            txtFname.Text = null;
            txtLname.Text = null;
            txtPhone.Text = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFname.Text == "" || txtLname.Text == "" || txtID.Text == "" || txtPhone.Text == "")
                {
                    throw new Error("Please Make Sure All Data Is Entered");
                }
                else if (txtPhone.Text.Length > 10 || txtPhone.Text.Length < 10)
                {
                    throw new Error("Phone Number Needs To Be 10 Digits");
                }
                else
                {
                    try
                    {
                        h1.updateCust(txtFname.Text, txtLname.Text, txtPhone.Text, int.Parse(txtID.Text), "updateOwner");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Make Sure Id is Correct");
                    }
                }
            }
            catch (Error e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
    }
}
