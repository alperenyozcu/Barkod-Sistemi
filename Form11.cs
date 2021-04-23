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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        private string seciliveri1;
        private int adet;
        private void Form11_Load(object sender, EventArgs e)
        {
            baglanti("SELECT * FROM toptanci");

        }



        public void baglanti(string veri) // Veritabanının Bağlandığı Fonksiyon
        {
            gunaDataGridView2.Columns.Clear(); // Ana Tablonun İçeriği Temizlenir.
            SqlConnection conn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            SqlDataAdapter dataadapter = new SqlDataAdapter(veri, conn);
            DataSet dataset = new DataSet();
            dataadapter.Fill(dataset);
            gunaDataGridView2.DataSource = dataset.Tables[0];
            conn.Close();
        }
        public void baglanti2(string veri) // Veritabanının Bağlandığı Fonksiyon
        {
            gunaDataGridView1.Columns.Clear(); // Ana Tablonun İçeriği Temizlenir.
            SqlConnection conn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            SqlDataAdapter dataadapter = new SqlDataAdapter(veri, conn);
            DataSet dataset = new DataSet();
            dataadapter.Fill(dataset);
            gunaDataGridView1.DataSource = dataset.Tables[0];
            conn.Close();
        }

        public string toptanciID;
        private void gunaDataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            toptanciID = gunaDataGridView2.CurrentRow.Cells[0].Value.ToString();
            baglanti2("Select * from urun where toptanciID LIKE " + toptanciID + "");

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if ((String.IsNullOrEmpty(guna2TextBox18.ToString())) && (String.IsNullOrEmpty(guna2TextBox1.ToString())))
            {
                MessageBox.Show("Lütfen Gerekli Alanları Doldurunuz");
            }
            else
            {
                try
                {


                    SqlConnection baglanti = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into toptanci (toptanciisim,toptanciiletisim) values (@toptanciisim,@toptanciiletisim)", baglanti);
                    komut.Parameters.AddWithValue("@toptanciisim", guna2TextBox18.Text);
                    komut.Parameters.AddWithValue("@toptanciiletisim", guna2TextBox1.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt Başarılı!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("satır44" + ex.ToString());

                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            baglanti("SELECT * FROM toptanci");
        }

        private void gunaDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int rowindex = gunaDataGridView1.CurrentCell.RowIndex; // Hücrenin Üst Satırının Dizinini Alır. //Seçili olan dizindeki 1.sütünun içindeki veriyi alır
            seciliveri1 = gunaDataGridView1.Rows[rowindex].Cells[0].Value.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(guna2TextBox2.Text.ToString()))
            {
                MessageBox.Show(" Lütfen İade Edilecek Adet Giriniz!");
            }
            else
            {

                try
                {

                    adet = Convert.ToInt32(guna2TextBox2.Text);
                    string barkod = gunaDataGridView1.CurrentRow.Cells["barkod"].Value.ToString();   
                    SqlConnection conn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;"); // Veritabanı Bağlantısı Sağlanır.
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("stokiade", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@adet", SqlDbType.Int);
                    cmd.Parameters.Add("@barkod", SqlDbType.VarChar, 15);
                    cmd.Parameters["@adet"].Value = adet.ToString();
                    cmd.Parameters["@barkod"].Value = barkod;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("İade Başarılı");
                    guna2TextBox2.Clear();
                    baglanti2("Select * from urun where toptanciID LIKE " + toptanciID + "");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            


                SqlConnection conn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                conn.Open();
                SqlCommand komut = new SqlCommand("select * from urun where barkod  like '%" + guna2TextBox3.Text + "%' and toptanciID  LIKE " + toptanciID + "  ", conn);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataSet dataset = new DataSet();
                da.Fill(dataset);
                gunaDataGridView1.DataSource = dataset.Tables[0];
                conn.Close();
            
        }
    }
}
