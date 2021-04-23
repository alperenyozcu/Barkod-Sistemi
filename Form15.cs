using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace ShoeZone
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); // Dosya Seçmek için İletişim Kutusunu Aç. 
            file.Filter = "Excel Dosyası(.xls)|*.xls*";
            file.Title = "Table Import";
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) // Kullanıcı Tarafından Seçilen Bir Dosya Olup Olmadığını Kontrol Eder.
            {
                filePath = file.FileName; // Dosyanın Yolunu Kaydeder.  
                fileExt = Path.GetExtension(filePath); // Dosya Uzantısını Kaydeder.
                guna2TextBox1.Text = filePath;


                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0) // Dosyanın Uzantısı Kontrol Edilir.
                {
                    // Hata Komutları
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = ReadExcel(filePath, fileExt); // Excel Dosyasını Okur. 
                        gunaDataGridView1.Visible = true;
                        gunaDataGridView1.DataSource = dtExcel;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Sadece .xls veya .xlsx Uzantılı Bir Dosya Seçin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error); // Uyarı Gösteren Mesaj Kutusu  
                }
            }
        }
        private DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';";
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';";
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                // Hata Komutları
                try
                {

                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sayfa1$]", con); // Sayfa1'in İçindeki Verileri Oku  
                    oleAdpt.Fill(dtexcel); // Excel Verilerini Tablolara Aktar.  
                }
                catch { }
            }
            return dtexcel;

        }
        private void satisimport() // Veritabanına Bağlan, Veritabanını Aç, Veritabanına Ekle Komutunu ve Hangi Parametrelerin Ekleneceğini Gir, Veritabanını Kapat.
        {
            // Hata Komutları
            try
            {
                for (int i = 0; i < gunaDataGridView1.Rows.Count - 1; i++)
                {
                    SqlConnection baglanti = new SqlConnection("Server = localhost; Database =  ayakkabistok  ; Integrated Security = SSPI;");
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into satislar (barkod,urunadi,satisfiyat,musteriadi,musterisoyadi,satistarih,telno,ödemetipi) values (@barkod ,@urunadi ,@satisfiyat ,@musteriadi ,@musterisoyadi ,@satistarih ,@telno ,@ödemetipi)", baglanti);
                    komut.Parameters.AddWithValue("@barkod", gunaDataGridView1.Rows[i].Cells["barkod"].Value.ToString());
                    komut.Parameters.AddWithValue("@urunadi", gunaDataGridView1.Rows[i].Cells["urunadi"].Value.ToString());
                    komut.Parameters.AddWithValue("@satisfiyat", gunaDataGridView1.Rows[i].Cells["satisfiyat"].Value.ToString());
                    komut.Parameters.AddWithValue("@musteriadi", gunaDataGridView1.Rows[i].Cells["musteriadi"].Value.ToString());
                    komut.Parameters.AddWithValue("@musterisoyadi", gunaDataGridView1.Rows[i].Cells["musterisoyadi"].Value.ToString());
                    komut.Parameters.AddWithValue("@satistarih",Convert.ToDateTime( gunaDataGridView1.Rows[i].Cells["satistarih"].Value.ToString()));
                    komut.Parameters.AddWithValue("@telno", gunaDataGridView1.Rows[i].Cells["telno"].Value.ToString());
                    komut.Parameters.AddWithValue("@ödemetipi", gunaDataGridView1.Rows[i].Cells["ödemetipi"].Value.ToString());
            
                    komut.ExecuteNonQuery(); // Kodu SQL'de Çalıştırıp Geriye Değer Döndüren Metod.
                    baglanti.Close();
                }
                MessageBox.Show("Gerçekleşti!"); // Mesaj Kutusu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Hata Meydana Geldi  :" + ex.ToString());
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            satisimport();
        }
    }
}
