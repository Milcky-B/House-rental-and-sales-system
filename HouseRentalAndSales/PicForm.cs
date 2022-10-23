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
    public partial class PicForm : Form
    {
        Handle h;
        public PicForm()
        {
            InitializeComponent();
            h = new Handle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "choose Photo(*.jpg; *.png; *.jpeg; *.bmp; ) | " +
                       "*.jpg; *.png; *.Jpeg; *.bmp; ";

            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackgroundImage = Image.FromFile(op.FileName);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.BackgroundImage == null)
                {
                    throw new Error("Please Enter Image");
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.BackgroundImage.Save(ms, pictureBox1.BackgroundImage.RawFormat);
                    byte[] photo = ms.ToArray();
                    h.addPicture(int.Parse(textBox1.Text), photo);
                }
            }
            catch(Error e1)
            {
                MessageBox.Show(e1.Message);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please Enter A valid ID");
            }
        }
    }
}
