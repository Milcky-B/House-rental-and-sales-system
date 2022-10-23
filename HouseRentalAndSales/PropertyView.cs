using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseRentalAndSales
{
    public partial class PropertyView : Form
    {
        Handle h;
        int amount = 0;
        DataTable dt;
        int pos = 0;
        public PropertyView(string propID, string ownerID, string Address, string houseType, string rooms, string price, string type)
        {
            InitializeComponent();
            txtProp.Text = propID;
            txtOwn.Text = ownerID;
            txtAdd.Text = Address;
            txtA.Text = houseType;
            txtHouse.Text = rooms;
            txtRoom.Text = price;
            txtPrice.Text = type;
            h = new Handle();
            pictures();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void pictures()
        {
            try
            {
                dt = h.searchImage(int.Parse(txtProp.Text));
                amount = dt.Rows.Count;
                propImage.BackgroundImage = Image.FromStream(new MemoryStream((byte[])dt.Rows[0]["pic"]));
                lblAmount.Text = amount.ToString();
                amount -= 1;
                lblF.Text = "1";
            }
            catch (FormatException)
            {

            }
            catch (InvalidCastException)
            {
                amount = 0;
            }
        }

        private void imagesDisplay(int i)
        {
            if (amount == 0)
            {
                MessageBox.Show("No Images To Display");
            }
            else if (i < 0)
            {
                MessageBox.Show("First Image");
                pos = 0;    
            }
            else if (i > amount)
            {
                MessageBox.Show("Last Image");
                pos = amount;
            }
            else
            {
                propImage.BackgroundImage = Image.FromStream(new MemoryStream((byte[])dt.Rows[i]["pic"]));
                lblF.Text = (i + 1).ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pos += 1;
            imagesDisplay(pos);
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            pos -= 1;
            imagesDisplay(pos);
        }
    }
}
