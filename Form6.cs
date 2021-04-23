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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        public string barkodgonder2;
        public string barkod, alisfiyat, karoran, satisfiyat;
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

        private void Guna2Button3_Click(object sender, EventArgs e)
        {
            hesaplama();
        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            barkod = guna2TextBox4.Text;
            alisfiyat = guna2TextBox1.Text;
            karoran = guna2TextBox2.Text;
            satisfiyat = guna2TextBox3.Text;
            try
            {

                ((Form1)Application.OpenForms["Form1"]).cuzdankaydet();
            }
            catch (Exception ex)
            {//"Lütfen Bütün alanların sırası ile doldurulduğundan ve her alanın dolu olduğundan emin olun"
                MessageBox.Show(ex.ToString()); ;
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
        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            satisfiyathesapla();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            barkodgonder2 = ((Form1)Application.OpenForms["Form1"]).barkod2;
            guna2TextBox4.Text = barkodgonder2;
        }
    }
}
