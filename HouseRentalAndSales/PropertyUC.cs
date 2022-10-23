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
    public partial class PropertyUC : UserControl
    {
        private Handle h;
        public PropertyUC()
        {
            InitializeComponent();
            h = new Handle();
        }

        private void PropertyUC_Load(object sender, EventArgs e)
        {

        }

        private void cmbtype_KeyUp(object sender, KeyEventArgs e)
        {
            cmbtype.Text = "";
            MessageBox.Show("Please choose from the alternatives");
        }

        private void cmbstatus_KeyUp(object sender, KeyEventArgs e)
        {
            cmbstatus.Text = "";
            MessageBox.Show("Please choose from the alternatives");
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            comboBox1.Text = "";
            MessageBox.Show("Please choose from the alternatives");
        }

        private void searchTxt_MouseClick(object sender, MouseEventArgs e)
        {
            searchTxt.Text = "";
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = h.getProperty("searchByOwnerID", int.Parse(searchTxt.Text));
                foreach (DataRow dr in dt.Rows)
                {
                    txtProperty.Text = dr["PropId"].ToString();
                    txtOwnerID.Text = dr["OwnID"].ToString();
                    txtAdress.Text = dr["Adress"].ToString();
                    comboBox1.Text = dr["SaleType"].ToString();
                    cmbtype.Text = dr["HouseType"].ToString();
                    cmbstatus.Text = dr["statuss"].ToString();
                    numericUpDown1.Value =int.Parse(dr["rooms"].ToString());
                    txtPrice.Text = dr["price"].ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please Enter A Correct ID");
            }
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = h.getProperty("searchByPropertyID", int.Parse(textBox4.Text));
                foreach (DataRow dr in dt.Rows)
                {
                    txtProperty.Text = dr["PropId"].ToString();
                    txtOwnerID.Text = dr["OwnID"].ToString();
                    txtAdress.Text = dr["Adress"].ToString();
                    comboBox1.Text = dr["SaleType"].ToString();
                    cmbtype.Text = dr["HouseType"].ToString();
                    cmbstatus.Text = dr["statuss"].ToString();
                    numericUpDown1.Value = int.Parse(dr["rooms"].ToString());
                    txtPrice.Text = dr["price"].ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please Enter A Correct ID");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtProperty.Text == "" ||  txtAdress.Text =="" ||comboBox1.Text =="" ||cmbtype.Text =="" ||cmbstatus.Text =="" || txtPrice.Text == "")
                {
                    throw new Error("Please Enter Data On Each Box");
                }
                else
                {
                    h.updateProperty(txtAdress.Text, cmbtype.Text, cmbstatus.Text, comboBox1.Text, int.Parse(txtPrice.Text), (int)(numericUpDown1.Value), int.Parse(txtProperty.Text));
                }
            }
            catch(Error e1)
            {
                MessageBox.Show(e1.Message);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please Make Sure Data is in correct format ");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Please Make Sure Data is in correct format ");
            }
}

        private void button1_Click(object sender, EventArgs e)
        {
            PicForm pf = new PicForm();
            pf.Visible = true;
        }
    }
}
