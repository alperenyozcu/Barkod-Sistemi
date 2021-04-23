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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        public string barkodgonder3;
        public string barkod, alisfiyat, karoran, satisfiyat;

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            satisfiyathesapla();
        }

        private void Guna2Button3_Click(object sender, EventArgs e)
        {
            hesaplama();
        }

        private void Guna2Button2_Click(object sender, EventArgs e)// cantaekle fonk calistir
        {
            barkod = guna2TextBox4.Text;
            alisfiyat = guna2TextBox1.Text;
            karoran = guna2TextBox2.Text;
            satisfiyat = guna2TextBox3.Text;
            try
            {

                ((Form1)Application.OpenForms["Form1"]).cantaekle();
            }
            catch (Exception ex)
            {//"Lütfen Bütün alanların sırası ile doldurulduğundan ve her alanın dolu olduğundan emin olun"
                MessageBox.Show(ex.ToString()); ;
            }

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            barkodgonder3 = ((Form1)Application.OpenForms["Form1"]).barkod3;// barkod 3 
            guna2TextBox4.Text = barkodgonder3;

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
    }
}
