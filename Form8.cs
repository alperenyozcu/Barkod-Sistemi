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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        public int toplam=0;
        public int tutar = 0;

        private void PictureBox1_Click(object sender, EventArgs e)//5 tl ekle
        {
            toplam += 5;

            guna2TextBox2.Text = toplam.ToString() ;
          
        }

        private void PictureBox2_Click(object sender, EventArgs e)//10 tl ekle
        {
            toplam += 10;
            guna2TextBox2.Text = toplam.ToString();

        }

        private void PictureBox3_Click(object sender, EventArgs e)// 20 tl ekle
        {
            toplam += 20;
            guna2TextBox2.Text = toplam.ToString();
        }

        private void PictureBox4_Click(object sender, EventArgs e)// 50 tl ekle
        {
            toplam += 50;
            guna2TextBox2.Text = toplam.ToString();
        }

        private void PictureBox5_Click(object sender, EventArgs e)// 100 tl ekle
        {
            toplam += 100;
            guna2TextBox2.Text = toplam.ToString();
        }

        private void PictureBox6_Click(object sender, EventArgs e)// 200 tl ekle 
        {
            toplam += 200;
            guna2TextBox2.Text = toplam.ToString();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            guna2TextBox1.Text = ((Form1)Application.OpenForms["Form1"]).fiyat.ToString();
            
            guna2TextBox2.Text = "0";
            guna2TextBox3.Text = "0";
            tutar = Convert.ToInt32(guna2TextBox1.Text);
          
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int sonuc = toplam - tutar;
            guna2TextBox3.Text = sonuc.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            toplam = 0;
            guna2TextBox2.Text = 0.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ((Form1)Application.OpenForms["Form1"]).satısekle();
            ((Form1)Application.OpenForms["Form1"]).texboxtemizle();


        }
    }
}
