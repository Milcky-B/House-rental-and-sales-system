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
    public partial class Employees : UserControl
    {
        Handle h1;
        public Employees()
        {
            InitializeComponent();
            h1 = new Handle();
            addValues();
        }
        private void addValues()
        {
            dataGridView1.DataSource = h1.getID("sendEmp");
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            comboBox1.Text = "";
            MessageBox.Show("Choose From The Alternatives");
        }
        private void clear(Control s)
        {
            s.Text = "";
        }
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string fname= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string lname= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtName.Text = fname + " " + lname ;
            txtID.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPass.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear(txtPass);
            clear(txtName);
            clear(txtID);
            clear(comboBox1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtPass.Text == "" || comboBox1.Text == "")
                {
                    throw new Error("Please Enter All Data");
                }
                int i = -1;
                txtName.Text = txtName.Text.Trim(' ');
                i = txtName.Text.IndexOf(" ");
                if (i == -1)
                {
                    throw new Error("Please Enter First Name and Last Name Accordingly");
                }
                else
                {
                    string []fn = txtName.Text.Split(' ');
                    string id = h1.addEmp(fn[0], fn[1], txtPass.Text, comboBox1.Text);
                    txtID.Text = id;
                    addValues();
                }
            }
            catch(Error e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == " " || txtPass.Text == " " || comboBox1.Text == " ")
                {
                    throw new Error("Please Enter All Data");
                }
                int i = -1;
                txtName.Text = txtName.Text.Trim(' ');
                i = txtName.Text.IndexOf(" ");
                if (i == -1)
                {
                    throw new Error("Please Enter First Name and Last Name Accordingly");
                }
                else
                {
                    string[] fn = txtName.Text.Split(' ');
                    h1.updateEmployee(fn[0], fn[1], txtPass.Text, comboBox1.Text, int.Parse(txtID.Text));
                    addValues();
                }
            }
            catch (Error e1)
            {
                MessageBox.Show(e1.Message);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please Check Employee ID");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string i;
            i=MessageBox.Show("Are You Sure You Want To Delete Employee", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if (i.CompareTo("Yes") == 0)
            {
                try
                {
                    h1.deleteEmp(int.Parse(txtID.Text), "deleteEmp");
                    addValues();
                }
                catch(FormatException)
                {
                    MessageBox.Show("Check ID");
                }
            }
            
        }
    }
}
