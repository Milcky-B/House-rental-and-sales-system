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
    public partial class RemoveControl : UserControl
    {
        Handle h1;
        
        public RemoveControl()
        {
            InitializeComponent();
            h1 = new Handle();
        }

        private void btnCust_Click(object sender, EventArgs e)
        {
            string i;
            i = MessageBox.Show("Are You Sure You Want To Customer", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (i.CompareTo("Yes") == 0)
            {
                try
                {
                    h1.deleteEmp(int.Parse(textBox1.Text), "DeleteCustomer");
                    
                }
                catch (FormatException)
                {
                    MessageBox.Show("Check ID");
                }
                catch (Error e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void btnOwner_Click(object sender, EventArgs e)
        {
            string i;
            i = MessageBox.Show("Are You Sure You Want To Delete Owner", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (i.CompareTo("Yes") == 0)
            {
                try
                {
                    h1.deleteEmp(int.Parse(textBox1.Text), "DeleteOwner");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Check ID");
                }
                catch (Error e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void btnProperty_Click(object sender, EventArgs e)
        {
            string i;
            i = MessageBox.Show("Are You Sure You Want To Delete Property", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (i.CompareTo("Yes") == 0)
            {
                try
                {
                    h1.deleteEmp(int.Parse(textBox1.Text), "DeleteProperty");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Check ID");
                }
                catch(Error e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
