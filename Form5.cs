using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoeZone
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Guna2TileButton1_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.ShowDialog();
            this.Close();

        }

        private void Guna2TileButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kredi kartı ile satışı onaylıyormusunuz?\n", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ((Form1)Application.OpenForms["Form1"]).satısekle();
                ((Form1)Application.OpenForms["Form1"]).texboxtemizle();
            }
            else
            {
                MessageBox.Show("Satış Gerçekleşmedi");
                
            }
            this.Close();
        }
    }
}
