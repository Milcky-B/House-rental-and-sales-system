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
    public partial class Search : UserControl
    {
        Handle h;
        public Search()
        {
            InitializeComponent();
            h = new Handle();
        }

        private void cmbRent_KeyUp(object sender, KeyEventArgs e)
        {
            cmbRent.Text = "";
            MessageBox.Show("Choose From The Alternatives");
        }

        private void cmbType_KeyUp(object sender, KeyEventArgs e)
        {
            cmbType.Text = "";
            MessageBox.Show("Choose From The Alternatives");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbType.Text = "";
            cmbRent.Text = "";
            minPrice.Text = "";
            minRoom.Value = 0;
            maxPrice.Text = "";
            maxRoom.Value = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (maxRoom.Value <= minRoom.Value)
                {
                    throw new Error("Please Check Room Range");
                }
                else if (int.Parse(maxPrice.Text) <= int.Parse(minPrice.Text))
                {
                    throw new Error("Please Check Price Range");
                }
                else if(cmbType.Text=="" || cmbRent.Text == "")
                {
                    throw new Error("Please Enter Data On All Fields");
                }
                else
                {
                   dgv.DataSource=h.searchProperty((int)minRoom.Value, (int)maxRoom.Value, int.Parse(minPrice.Text),
                   int.Parse(maxPrice.Text), cmbType.Text, cmbRent.Text);
                }
            }
            catch(Error e1)
            {
                MessageBox.Show(e1.Message);
            }
            catch (FormatException)
            {
                MessageBox.Show("Check Data Type");
            }
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PropertyView pv = new PropertyView(dgv.CurrentRow.Cells[0].Value.ToString(), dgv.CurrentRow.Cells[1].Value.ToString(),
                dgv.CurrentRow.Cells[2].Value.ToString(), dgv.CurrentRow.Cells[3].Value.ToString(), 
                dgv.CurrentRow.Cells[4].Value.ToString(), dgv.CurrentRow.Cells[6].Value.ToString(),
                dgv.CurrentRow.Cells[7].Value.ToString());
            pv.Visible = true;
        }
    }
}
