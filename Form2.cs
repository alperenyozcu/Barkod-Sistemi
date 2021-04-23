using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShoeZone
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string barkodgonder;
        private void Form2_Load(object sender, EventArgs e)
        {
          
            barkodgonder = ((Form1)Application.OpenForms["Form1"]).barkod;
            guna2TextBox4.Text = barkodgonder;
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

        private void Guna2Button1_Click(object sender, EventArgs e)//satış fiyatı
        {
            if ((!String.IsNullOrEmpty(guna2TextBox1.Text)) && (!String.IsNullOrEmpty(guna2TextBox2.Text)))
            {
                float alisfiyat = float.Parse(guna2TextBox1.Text);
                float karoran = float.Parse(guna2TextBox2.Text);
                float sonuc = alisfiyat * karoran / 100 + alisfiyat;
                guna2TextBox3.Text = sonuc.ToString();
            }
        }
        public void fiyatekle()
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into fiyatbilgi ( barkod ,alisfiyat ,karoran ,satisfiyat) values (@barkod,@alisfiyat,@karoran,@satisfiyat)", baglanti);
                komut.Parameters.AddWithValue("@barkod", barkod);
                komut.Parameters.AddWithValue("@alisfiyat",float.Parse(alisfiyat));
                komut.Parameters.AddWithValue("@karoran",  float.Parse(karoran));
                komut.Parameters.AddWithValue("@satisfiyat",float.Parse(satisfiyat));
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarılı!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Guna2Button3_Click(object sender, EventArgs e)
        {
            hesaplama();
        }
        public String barkod, alisfiyat, karoran, satisfiyat;
        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            barkod = guna2TextBox4.Text;
            alisfiyat = guna2TextBox1.Text;
            karoran = guna2TextBox2.Text;
            satisfiyat = guna2TextBox3.Text;
            fiyatekle();
            ((Form1)Application.OpenForms["Form1"]).Ayakkabiekle();
            
            this.Close();
        }
    }
}
