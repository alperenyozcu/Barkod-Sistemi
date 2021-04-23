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
    public partial class saatguncelle : Form
    {
        public saatguncelle()
        {
            InitializeComponent();
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
           ((Form1)Application.OpenForms["Form1"]).saatguncelle(guna2TextBox2.Text, guna2TextBox3.Text, guna2TextBox4.Text, guna2TextBox5.Text, guna2TextBox6.Text);
            this.Close();
        }

        private void Saatguncelle_Load(object sender, EventArgs e)
        {
            string b2 = "", b3 = "", b4 = "", b5 = "", b6 = "", b7 = "";
            ((Form1)Application.OpenForms["Form1"]).saatoku(ref b2, ref b3, ref b4, ref b5, ref b6, ref b7); // Form3 Açılır ve bilgisayaroku Fonksiyonu Getirilir.

            // Metin Kutularına Metin Ataması Yapılır.
            guna2TextBox1.Text = b2;
            guna2TextBox2.Text = b3;
            guna2TextBox3.Text = b4;
            guna2TextBox4.Text = b5;
            guna2TextBox5.Text = b6;
            guna2TextBox6.Text = b7;
        }
        public void hesaplama()//karoranı
        {
            if ((!String.IsNullOrEmpty(guna2TextBox1.Text)) && (!String.IsNullOrEmpty(guna2TextBox3.Text)))
            {

                float alisfiyat = float.Parse(guna2TextBox4.Text);
                float satisfiyat = float.Parse(guna2TextBox6.Text);
                float karoran = 100 * (satisfiyat - alisfiyat) / alisfiyat;
                guna2TextBox5.Text = karoran.ToString();

            }
        }
        public void satisfiyathesapla()
        {

            if ((!String.IsNullOrEmpty(guna2TextBox1.Text)) && (!String.IsNullOrEmpty(guna2TextBox2.Text)))
            {
                float alisfiyat = float.Parse(guna2TextBox4.Text);
                float karoran = float.Parse(guna2TextBox5.Text);
                float sonuc = alisfiyat * karoran / 100 + alisfiyat;
                guna2TextBox6.Text = sonuc.ToString();

            }
        }

        private void Guna2Button3_Click(object sender, EventArgs e)
        {
            hesaplama();
        }

        private void Guna2Button4_Click(object sender, EventArgs e)
        {
            satisfiyathesapla();
        }
    }
}
