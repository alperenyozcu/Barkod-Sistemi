using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShoeZone
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        
        public void hesaplama()//karoranı
        {
            if ((!String.IsNullOrEmpty(guna2TextBox1.Text)) && (!String.IsNullOrEmpty(guna2TextBox3.Text)))
            {

                float alisfiyat = float.Parse(guna2TextBox1.Text);
                float satisfiyat = float.Parse(guna2TextBox3.Text);
                float karoran = 100 * (satisfiyat - alisfiyat) / alisfiyat;
                guna2TextBox2.Text = karoran.ToString();

            }
        }
        public void satisfiyathesapla()
        {
            if ((!String.IsNullOrEmpty(guna2TextBox1.Text)) && (!String.IsNullOrEmpty(guna2TextBox2.Text)))
            {
                float alisfiyat = float.Parse(guna2TextBox1.Text);
                float karoran = float.Parse(guna2TextBox2.Text);
                float sonuc = alisfiyat * karoran / 100 + alisfiyat;
                guna2TextBox3.Text = sonuc.ToString();

            }
        }
        public string barkod, alisfiyat, karoran, satisfiyat;
        private void Guna2Button2_Click(object sender, EventArgs e)
        {
           
              barkod = guna2TextBox4.Text;
             alisfiyat = guna2TextBox1.Text;
             karoran = guna2TextBox2.Text;
             satisfiyat= guna2TextBox3.Text;
            try
            {

                ((Form1)Application.OpenForms["Form1"]).saatekle();
            }
           catch(Exception ex)
            {
                MessageBox.Show("Lütfen Bütün alanların sırası ile doldurulduğundan ve her alanın dolu olduğundan emin olun");
            }
           
         
        }
        
        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            satisfiyathesapla();
        }

        private void Guna2Button3_Click(object sender, EventArgs e)
        {
            hesaplama();
        }
        public string barkodgonder1;
        private void Form4_Load(object sender, EventArgs e)
        {
            barkodgonder1 = ((Form1)Application.OpenForms["Form1"]).barkod1;
            guna2TextBox4.Text = barkodgonder1;

        }
    }
}
