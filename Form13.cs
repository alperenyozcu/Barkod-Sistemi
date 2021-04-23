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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        private string seciliveri1;
        private void Form13_Load(object sender, EventArgs e)
        {
            baglanti("Select * from satislar");
          
        }
       
        public void baglanti(string veri) // Veritabanının Bağlandığı Fonksiyon
        {
            dataGridView1.Columns.Clear(); // Ana Tablonun İçeriği Temizlenir.
            SqlConnection conn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            SqlDataAdapter dataadapter = new SqlDataAdapter(veri, conn);
            DataSet dataset = new DataSet();
            dataadapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
            conn.Open();
            SqlCommand komut = new SqlCommand("select * from satislar where barkod  like '%" + textBox1.Text + "%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet dataset = new DataSet();
            da.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            conn.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
            conn.Open();
            SqlCommand komut = new SqlCommand("select * from satislar where musteriadi  like '%" + textBox2.Text + "%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet dataset = new DataSet();
            da.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            conn.Close();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
            conn.Open();
            SqlCommand komut = new SqlCommand("select * from satislar where telno  like '%" + textBox3.Text + "%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet dataset = new DataSet();
            da.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            conn.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex; // Hücrenin Üst Satırının Dizinini Alır. //Seçili olan dizindeki 1.sütünun içindeki veriyi alır
                seciliveri1 = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata! Form13 satır87");
            }
        }
        public void iadeal(string barkod,string musteriadi,string telno,string urunadi,DateTime satistarih)
        {
            try
            {
                SqlCommand komut;
                SqlConnection con = new SqlConnection("Server = localhost; Database =ayakkabistok; Integrated Security = SSPI;"); // Veritabanına Bağlanılmasını Sağlar.
                if (MessageBox.Show("Seçilen Ürünü İade Almak İstediğinize Emin Misiniz?\n", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string sql = "DELETE FROM satislar WHERE barkod=@barkod and musteriadi=@musteriadi and telno=@telno and urunadi=@urunadi and satistarih=@satistarih";
                    komut = new SqlCommand(sql, con);
                    komut.Parameters.AddWithValue("@barkod", barkod);
                    komut.Parameters.AddWithValue("@musteriadi", musteriadi);
                    komut.Parameters.AddWithValue("@telno", telno);
                    komut.Parameters.AddWithValue("@urunadi", urunadi);
                    komut.Parameters.AddWithValue("@satistarih", satistarih);
                    con.Open();
                    komut.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("İade Alma Başarılı Ürün Stoklara Geri eklendi");
                }
                else
                {
                    MessageBox.Show("İade Alma Gerçekleşmedi..");
                    con.Close();
                }
                baglanti("Select * from satislar");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bir Hata Alındı Satır 121 form 13");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows) 
                {
                    if (dataGridView1.Rows.Count == 1)
                    {
                        MessageBox.Show("Lütfen Yeni Satış Yapınız");
                    }
                    else
                    {
                        string numara = drow.Cells[0].Value.ToString();
                        string musteriadi = drow.Cells["musteriadi"].Value.ToString();
                        string telno = drow.Cells["telno"].Value.ToString();
                        string urunadi = drow.Cells["urunadi"].Value.ToString();
                        DateTime satistarih = Convert.ToDateTime(drow.Cells["satistarih"].Value);
                        iadeal(numara, musteriadi, telno, urunadi, satistarih);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti("SELECT * FROM satislar where satistarih = CONVERT(DATE, GETDATE(), 104)");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti("Select * from satislar where satistarih>dateadd(day,-30,getdate())");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti("Select * from satislar where satistarih>dateadd(day,-365,getdate())");
        }
    }
}
