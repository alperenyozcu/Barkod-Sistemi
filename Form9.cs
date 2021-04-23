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
using System.Data.SqlClient;
using System.Data.OleDb;

namespace ShoeZone
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        private string secilitarih = "NULL";
        string today = DateTime.Today.ToString("yyyy-dd-MM");
        private void Form9_Load(object sender, EventArgs e)
        {
            gunaTextBox2.Text = " ";
            guna2ComboBox2.Items.Add("Günlük Satışlar Kredi Kart");
            guna2ComboBox2.Items.Add("Günlük Satışlar Nakit");
            guna2ComboBox2.Items.Add("Aylık Satışlar Kredi Kart");
            guna2ComboBox2.Items.Add("Aylık Satışlar Nakit");
            guna2ComboBox2.Items.Add("Yıllık Satışlar Kredi Kart");
            guna2ComboBox2.Items.Add("Yıllık Satışlar Nakit");

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
         
            FolderBrowserDialog dlg = new FolderBrowserDialog(); 
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gunaTextBox2.Text = dlg.SelectedPath;
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (secilitarih == "NULL")
            {
                MessageBox.Show("Lütfen Önce Dışa Aktarılacak Bir Tarih Seçin!");
            }
            else
            {
                if (gunaTextBox2.Text == string.Empty)
                {
                    MessageBox.Show("Lütfen Önce Kaydedilecek Bir Yer Seçin!");
                }
                else
                {
                    switccase(secilitarih);
                }

            }
        }
        void switccase( string tarih)
        {
            string sql = null;
            string sql1 = null;
            string sql2 = null;
            string sql3 = null;
            string sql4 = null;
            string sql5 = null;
            sql = "SELECT * FROM satislar where satistarih=CONVERT(DATE,GETDATE(),104) and ödemetipi LIKE 'Kredi Kartı' ";// günlüğe göre kK 
            sql3 = "SELECT * FROM satislar where satistarih=CONVERT(DATE,GETDATE(),104)  and ödemetipi LIKE 'Nakit'";// günlüğe göre nakit and ödemetipi LIKE 'Nakit'
            sql1 = "SELECT * FROM satislar where satistarih>dateadd(day,-30,getdate()) and ödemetipi LIKE 'Kredi Kartı'";//aylığa göre düzenle KK 
            sql4 = "SELECT * FROM satislar where satistarih>dateadd(day,-30,getdate()) and ödemetipi LIKE 'Nakit' ";//aylığa göre düzenle nakit
            sql2 = "SELECT * FROM satislar where satistarih>dateadd(day,-365,getdate()) and ödemetipi LIKE 'Kredi Kartı' ";// yıllığa göre düzenle KK 
            sql5 = "SELECT * FROM satislar where satistarih>dateadd(day,-365,getdate()) and ödemetipi LIKE 'Nakit'";//yıllığa göre düzenle nakit  
            string tabloadi = null;
            switch (tarih)
            {
                case "Günlük Satışlar Kredi Kart":
                    tabloadi = sql;
                    
                    this.Close();
                    ExportDataFromExcel(tabloadi, "Günlük Satışlar Kredi Kart");
                    break;

                case "Günlük Satışlar Nakit":
                    tabloadi = sql3;
                    
                    this.Close();
                    ExportDataFromExcel(tabloadi, "Günlük Satışlar Nakit");
                    break;
                case "Aylık Satışlar Kredi Kart":
                    tabloadi = sql1;
                   
                    this.Close();
                    ExportDataFromExcel(tabloadi, "Aylık Satışlar Kredi Kart");
                    break;
                case "Aylık Satışlar Nakit":
                    tabloadi = sql4;
                
                    this.Close();
                    ExportDataFromExcel(tabloadi, "Aylık Satışlar Nakit");
                    break;
                case "Yıllık Satışlar Kredi Kart":
                    tabloadi = sql2;
                 
                    this.Close();
                    ExportDataFromExcel(tabloadi, "Yıllık Satışlar Kredi Kart");
                    break;
                case "Yıllık Satışlar Nakit":
                    tabloadi = sql5;
                   
                    this.Close();
                    ExportDataFromExcel(tabloadi, "Yıllık Satışlar Nakit");
                    break;
            }
        }
        public void ExportDataFromExcel(string tabloadi,string tarih)
        {
                SqlConnection cnn;
                string connectionString = null;
                
                string data = null;
                int i = 0;
                int j = 0;
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);       
                connectionString = "Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
          
              
         
            SqlDataAdapter dscmd = new SqlDataAdapter(tabloadi, cnn);
                DataSet ds = new DataSet();
                dscmd.Fill(ds);


                using (SqlCommand command = new SqlCommand(tabloadi, cnn))
                {
               
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int z = 0; z < reader.FieldCount; z++)
                        {
                            xlWorkSheet.Cells[z + 1] = reader.GetName(z);
                            for (i = 1; i <= ds.Tables[0].Rows.Count; i++)
                            {
                                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                                {

                                    data = ds.Tables[0].Rows[i - 1].ItemArray[j].ToString();
                                    xlWorkSheet.Cells[i + 1, j + 1] = data;

                                }
                            }
                        }
                    }
                }
            xlWorkBook.SaveAs(gunaTextBox2.Text + "\\" + "" + tarih + " Tablosu" + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("Excel Dosyası Oluşturuldu!");

        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Bir Hata Oluştu!" + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilitarih = guna2ComboBox2.SelectedItem.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            f15.ShowDialog();
        }
    }
}
