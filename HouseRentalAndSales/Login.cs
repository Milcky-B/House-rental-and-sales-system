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
    public partial class Login : Form
    {
        private Handle han;
        public static int ID;
        public static string ROLE;
        public static string FULLNAME;
        public Login()
        {
            InitializeComponent();
            log.PerformClick();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void log_Click(object sender, EventArgs e)
        {

            if (CheckValues())
            {
                if (EmpIdTxt.Text == "" && EmpPasstxt.Text == "")
                {
                    label5.ForeColor = System.Drawing.Color.Red;
                    label6.ForeColor = System.Drawing.Color.Red;
                }
                else if (EmpIdTxt.Text == "")
                {
                    label5.ForeColor = System.Drawing.Color.Red;
                } 
                else if (EmpPasstxt.Text == "")
                {
                    label6.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                try
                {
                    han = new Handle(int.Parse(EmpIdTxt.Text), EmpPasstxt.Text);
                    if (han.getRole().Equals("Sales"))
                    {
                        ID = int.Parse(EmpIdTxt.Text);
                        FULLNAME = han.getFullName();
                        ROLE = "Sales";
                        SalesMain s = new SalesMain();
                        s.ShowDialog();
                        EmpIdTxt.Text = null;
                        EmpPasstxt.Text = null;
                    }
                    else if (han.getRole().Equals("HR"))
                    {
                        ID = int.Parse(EmpIdTxt.Text);
                        FULLNAME = han.getFullName();
                        ROLE = "Human Resource";
                        SalesMain s = new SalesMain();
                        s.ShowDialog();
                        EmpIdTxt.Text = null;
                        EmpPasstxt.Text = null;
                    }
                    else
                    {
                        label7.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (FormatException fe)
                {
                    MessageBox.Show(fe.Message);
                }
            }
        }
        private Boolean CheckValues()
        {
            label5.ForeColor = System.Drawing.Color.Beige;
            label6.ForeColor = System.Drawing.Color.Beige;
            label7.ForeColor = System.Drawing.Color.Beige;
            if (EmpIdTxt.Text == "" || EmpPasstxt.Text=="")
            {
                return true;
            }
            return false;
        }
    }
}
