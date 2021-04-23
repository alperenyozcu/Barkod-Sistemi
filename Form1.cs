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
using System.IO;
using System.Media;

namespace ShoeZone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string seciliveri1;
        private string seciliveri2;
        private string seciliveri3;
     

        public string olustural;
        public void olusturalekle()
        {
            guna2TextBox2.Text = olustural;

        }
        private void GunaDataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            int rowindex = gunaDataGridView1.CurrentCell.RowIndex; // Hücrenin Üst Satırının Dizinini Alır. //Seçili olan dizindeki 1.sütünun içindeki veriyi alır
            seciliveri1 = gunaDataGridView1.Rows[rowindex].Cells[0].Value.ToString();  // ''
            seciliveri3 = gunaDataGridView1.Rows[rowindex].Cells[1].Value.ToString();  // ''
        }
        private void GunaDataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int rowindex = gunaDataGridView2.CurrentCell.RowIndex; // Hücrenin Üst Satırının Dizinini Alır. //Seçili olan dizindeki 1.sütünun içindeki veriyi alır
                seciliveri2 = gunaDataGridView2.Rows[rowindex].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen Barkod Okutunuz");
            }
        }
        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            ses();
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }
        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            ses();
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }
        private void Guna2Button3_Click(object sender, EventArgs e)
        {
            ses();
            Form9 f9 = new Form9();
            f9.ShowDialog();
           /* panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;*/
        }
        public void Ayakkabiekle()
        {
            try
            {
                FileStream fs = new FileStream(label11.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] resim = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                SqlConnection baglanti = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into ayakkabi ( barkod ,urunadi ,renk ,numara ,cinsiyet ,cesit, toptanciID,stokadedi,img) values (@barkod,@urunadi,@renk,@numara,@cinsiyet,@cesit,@toptanciID,@stokadedi,@img)", baglanti);
                komut.Parameters.AddWithValue("@barkod", guna2TextBox2.Text);
                komut.Parameters.AddWithValue("@urunadi", guna2TextBox3.Text);
                komut.Parameters.AddWithValue("@renk", guna2TextBox4.Text);
                komut.Parameters.AddWithValue("@numara", guna2TextBox22.Text);
                komut.Parameters.AddWithValue("@cinsiyet", guna2ComboBox2.SelectedItem);
                komut.Parameters.AddWithValue("@cesit", guna2ComboBox3.SelectedItem);
                komut.Parameters.AddWithValue("@toptanciID", guna2ComboBox4.SelectedItem);
                komut.Parameters.AddWithValue("@stokadedi", guna2TextBox5.Text);
                komut.Parameters.Add("@img", SqlDbType.Image, resim.Length).Value = resim;
                komut.ExecuteNonQuery();
                SqlCommand komut1 = new SqlCommand("update urun set img=@img where barkod=@barkod ", baglanti);
                komut1.Parameters.AddWithValue("@barkod", guna2TextBox2.Text);
                komut1.Parameters.Add("@img", SqlDbType.Image, resim.Length).Value = resim;
                komut1.ExecuteNonQuery();
                baglanti.Close();
                guna2TextBox2.Clear();
                guna2TextBox3.Clear();
                guna2TextBox4.Clear();   
                guna2TextBox5.Clear();
                pictureBox1.Image = null;
                label11.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
            }
        }
        public void saatekle()
        {
            try
            {
                FileStream fs = new FileStream(label20.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] resim = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                SqlConnection baglanti = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into saat (barkod,urunadi,renk,cesit,stokadedi,img,alisfiyat,karoran,satisfiyat) values (@barkod,@urunadi,@renk,@cesit,@stokadedi,@img,@alisfiyat,@karoran,@satisfiyat)", baglanti);
                komut.Parameters.AddWithValue("@barkod", guna2TextBox6.Text);
                komut.Parameters.AddWithValue("@urunadi", guna2TextBox7.Text);
                komut.Parameters.AddWithValue("@renk", guna2TextBox8.Text);   
                komut.Parameters.AddWithValue("@cesit", guna2ComboBox5.SelectedItem);
                komut.Parameters.AddWithValue("@stokadedi", guna2TextBox9.Text);
                komut.Parameters.AddWithValue("@alisfiyat", float.Parse(((Form4)Application.OpenForms["Form4"]).alisfiyat));
                komut.Parameters.AddWithValue("@karoran", float.Parse(((Form4)Application.OpenForms["Form4"]).karoran));
                komut.Parameters.AddWithValue("@satisfiyat", float.Parse(((Form4)Application.OpenForms["Form4"]).satisfiyat));
                komut.Parameters.Add("@img", SqlDbType.Image, resim.Length).Value = resim;
                komut.ExecuteNonQuery();
                SqlCommand komut1 = new SqlCommand("update urun set img=@img where barkod=@barkod ", baglanti);
                komut1.Parameters.AddWithValue("@barkod", guna2TextBox6.Text);
                komut1.Parameters.Add("@img", SqlDbType.Image, resim.Length).Value = resim;
                komut1.ExecuteNonQuery();
                
                baglanti.Close();
                guna2TextBox6.Clear();
                guna2TextBox7.Clear();
                guna2TextBox8.Clear();
                guna2TextBox9.Clear();
                pictureBox2.Image = null;
                label20.Text = "";
                MessageBox.Show("Kayıt Başarılı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen Gerekli alanları doldurunuz");
            }
        }
        public void cuzdankaydet()
        {
            try
            {
                FileStream fs = new FileStream(label28.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] resim = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                SqlConnection baglanti = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into cuzdan (barkod,urunadi,renk,cesit,stokadedi,img,alisfiyat,karoran,satisfiyat) values (@barkod,@urunadi,@renk,@cesit,@stokadedi,@img,@alisfiyat,@karoran,@satisfiyat)", baglanti);
                komut.Parameters.AddWithValue("@barkod", guna2TextBox10.Text);
                komut.Parameters.AddWithValue("@urunadi", guna2TextBox11.Text);
                komut.Parameters.AddWithValue("@renk", guna2TextBox12.Text);
                komut.Parameters.AddWithValue("@cesit", guna2ComboBox6.SelectedItem);
                komut.Parameters.AddWithValue("@stokadedi", guna2TextBox13.Text);
                komut.Parameters.AddWithValue("@alisfiyat", float.Parse(((Form6)Application.OpenForms["Form6"]).alisfiyat));
                komut.Parameters.AddWithValue("@karoran", float.Parse(((Form6)Application.OpenForms["Form6"]).karoran));
                komut.Parameters.AddWithValue("@satisfiyat", float.Parse(((Form6)Application.OpenForms["Form6"]).satisfiyat));
                komut.Parameters.Add("@img", SqlDbType.Image, resim.Length).Value = resim;
                komut.ExecuteNonQuery();
                SqlCommand komut1 = new SqlCommand("update urun set img=@img where barkod=@barkod ", baglanti);
                komut1.Parameters.AddWithValue("@barkod", guna2TextBox10.Text);
                komut1.Parameters.Add("@img", SqlDbType.Image, resim.Length).Value = resim;
                komut1.ExecuteNonQuery();
               
                baglanti.Close();
                guna2TextBox10.Clear();
                guna2TextBox11.Clear();
                guna2TextBox12.Clear();
                guna2TextBox13.Clear();
                pictureBox3.Image = null;
                label28.Text = "";
                MessageBox.Show("Kayıt Başarılı!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata alındıııı" + ex.ToString());
            }  
        }
        public void cantaekle()
        {
            try
            {
                FileStream fs = new FileStream(label35.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] resim = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                SqlConnection baglanti = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into canta (barkod,urunadi,renk,cesit,stokadedi,img,alisfiyat,karoran,satisfiyat) values (@barkod,@urunadi,@renk,@cesit,@stokadedi,@img,@alisfiyat,@karoran,@satisfiyat)", baglanti);
                komut.Parameters.AddWithValue("@barkod", guna2TextBox17.Text);
                komut.Parameters.AddWithValue("@urunadi", guna2TextBox16.Text);
                komut.Parameters.AddWithValue("@renk", guna2TextBox15.Text);
                komut.Parameters.AddWithValue("@cesit", guna2ComboBox7.SelectedItem);
                komut.Parameters.AddWithValue("@stokadedi", guna2TextBox14.Text);
                komut.Parameters.AddWithValue("@alisfiyat", float.Parse(((Form7)Application.OpenForms["Form7"]).alisfiyat));
                komut.Parameters.AddWithValue("@karoran", float.Parse(((Form7)Application.OpenForms["Form7"]).karoran));
                komut.Parameters.AddWithValue("@satisfiyat", float.Parse(((Form7)Application.OpenForms["Form7"]).satisfiyat));
                komut.Parameters.Add("@img", SqlDbType.Image, resim.Length).Value = resim;
                komut.ExecuteNonQuery();
                SqlCommand komut1 = new SqlCommand("update urun set img=@img where barkod=@barkod ", baglanti);
                komut1.Parameters.AddWithValue("@barkod", guna2TextBox17.Text);
                komut1.Parameters.Add("@img", SqlDbType.Image, resim.Length).Value = resim;
                komut1.ExecuteNonQuery();
             
                baglanti.Close();
                guna2TextBox17.Clear();
                guna2TextBox18.Clear();
                guna2TextBox19.Clear();
                guna2TextBox20.Clear();
                pictureBox4.Image = null;
                label35.Text = "";
                MessageBox.Show("Kayıt Başarılı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen Gerekli alanları doldurunuz" + ex.ToString()) ;
            }
        }
        public void comboboxdoldur()
        {
            try
            {
                if (guna2ComboBox2.SelectedItem.ToString() == "Erkek")
                {
                    guna2ComboBox3.Items.Clear();
                    guna2ComboBox3.Items.Add("Bot");
                    guna2ComboBox3.Items.Add("Deri");
                    guna2ComboBox3.Items.Add("Spor");
                }
                else if (guna2ComboBox2.SelectedItem.ToString() == "Kadın")
                {
                    guna2ComboBox3.Items.Clear();
                    guna2ComboBox3.Items.Add("Çizme");
                    guna2ComboBox3.Items.Add("Spor");
                    guna2ComboBox3.Items.Add("Klasik");

                }
                else if (guna2ComboBox2.SelectedItem.ToString() == "Çocuk")
                {
                    guna2ComboBox3.Items.Clear();
                    guna2ComboBox3.Items.Add("Klasik");
                    guna2ComboBox3.Items.Add("Spor");

                }
                else if (guna2ComboBox2.SelectedItem.ToString()== "Terlik")
                {
                    guna2ComboBox3.Items.Clear();
                    guna2ComboBox3.Items.Add("İçeri Terlik");
                    guna2ComboBox3.Items.Add("Dışarı Terlik");
                }
                else
                {
                    MessageBox.Show("Lütfen Katagori seçimini yapınız");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }      
        }
        public void baglanti(string veri) // Veritabanının Bağlandığı Fonksiyon
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
        private void Form1_Load(object sender, EventArgs e)
        {
           

            for (int i = 10; i < 52; i++)
            {
                guna2ComboBox1.Items.Add(i);
            }
           
            guna2ComboBox2.Items.Add("Erkek");
            guna2ComboBox2.Items.Add("Kadın");
            guna2ComboBox2.Items.Add("Çocuk");
            guna2ComboBox2.Items.Add("Terlik");

            SqlConnection baglanti1 = new SqlConnection();
            baglanti1.ConnectionString = " Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM toptanci";
            komut.Connection = baglanti1;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti1.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                guna2ComboBox4.Items.Add(dr["toptanciID"]);
            }
            baglanti1.Close();



            guna2ComboBox5.Items.Add("Kadın Saat");
            guna2ComboBox5.Items.Add("Erkek Saat");
            guna2ComboBox6.Items.Add("Kadın Cüzdan");
            guna2ComboBox6.Items.Add("Erkek Cüzdan");
            guna2ComboBox7.Items.Add("Erkek Çanta");
            guna2ComboBox7.Items.Add("Bayan Çanta");
            guna2ComboBox7.Items.Add("Çocuk Çanta");
            guna2ComboBox7.Items.Add("Okul Çanta");
            baglanti("Select * from ayakkabi");
            //   DateTime da = new DateTime();
            label38.Text = DateTime.Today.ToString("yyyy-MM-dd");

            //   --dd MMMM yyyy dddd
            guna2ComboBox8.Items.Add("Nakit");
            guna2ComboBox8.Items.Add("Kredi Kartı");




        }
        
        private void Guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxdoldur();
        }
        public void ses()
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\click.wav";
            ses.SoundLocation = dizin;
            ses.Play();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            label11.Text = openFileDialog1.FileName;
        }
        public string barkod1;
        private void Guna2Button5_Click(object sender, EventArgs e)
        {
            ses();
            barkod1 = guna2TextBox6.Text;
            Form4 f4 = new Form4();
            f4.ShowDialog();
          //  saatekle();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
            label20.Text = openFileDialog1.FileName;
        }

        public string barkod2;
        private void Guna2Button6_Click(object sender, EventArgs e)
        {
            ses();
            barkod2 = guna2TextBox10.Text;
            Form6 f6 = new Form6();
            f6.ShowDialog();
           // cüzdanekle();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox3.ImageLocation = openFileDialog1.FileName;
            label28.Text = openFileDialog1.FileName;
        }
        public string barkod3;
        private void Guna2Button7_Click(object sender, EventArgs e)// burdayız saniyede aklımı kaçırdım
        {
            ses();
            barkod3 = guna2TextBox17.Text;
            //al bide burdan yak kapasite meselesi bak
            Form7 f7 = new Form7();
            f7.ShowDialog();
          //  cantaekle();
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox4.ImageLocation = openFileDialog1.FileName;
            label35.Text = openFileDialog1.FileName;

        }
        public String barkod;
        private void Guna2Button8_Click(object sender, EventArgs e)
        {
            ses();

            barkod = guna2TextBox2.Text;
            Form2 f2 = new Form2();
            f2.ShowDialog();
         
        }
       
        private void Guna2Button9_Click(object sender, EventArgs e)
        {
            ses();
            guna2Button16.Visible = true;
            guna2Button17.Visible = false;
            guna2Button18.Visible = false;
            guna2Button19.Visible = false;
            guna2Button20.Visible = true;
            guna2Button15.Visible = false;
            guna2Button21.Visible = false;
            guna2Button22.Visible = false;
 
         
            guna2TextBox21.Visible = true;
            label43.Visible = true;
         


            baglanti("select * from ayakkabi");

          
        }
        private void Guna2Button10_Click(object sender, EventArgs e)
        {
            ses();
            guna2Button16.Visible = false;
            guna2Button17.Visible = true;
            guna2Button18.Visible = false;
            guna2Button19.Visible = false;
            guna2Button20.Visible = false;
            guna2Button15.Visible = true;
            guna2Button21.Visible = false;
            guna2Button22.Visible = false;
       
            guna2TextBox21.Visible = false;
            label43.Visible = false;

            baglanti("select * from saat");
        }
        private void Guna2Button12_Click(object sender, EventArgs e)
        {
            ses();
            guna2Button16.Visible = false;
            guna2Button17.Visible = false;
            guna2Button18.Visible = true;
            guna2Button19.Visible = false;
            guna2Button20.Visible = false;
            guna2Button15.Visible = false;
            guna2Button21.Visible = true;
            guna2Button22.Visible = false;
        
            guna2TextBox21.Visible = false;
            label43.Visible = false;

            baglanti("select * from cuzdan");
        }
        private void Guna2Button11_Click(object sender, EventArgs e)
        {
            ses();
            guna2Button16.Visible = false;
            guna2Button17.Visible = false;
            guna2Button18.Visible = false;
            guna2Button19.Visible = true;
            guna2Button20.Visible = false;
            guna2Button15.Visible = false;
            guna2Button21.Visible = false;
            guna2Button22.Visible = true;
       
            guna2TextBox21.Visible = false;
            label43.Visible = false;

            baglanti("select * from canta");
        }
        private void ara(string tabloadi, string aranacakyer, string aranacakveri)
        {
            SqlConnection conn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;"); // Veritabanı Bağlantısı Sağlanır.
            SqlCommand cmd = new SqlCommand("arama", conn); 
            cmd.CommandType = CommandType.StoredProcedure; 
            cmd.Parameters.Add("@tabloadi", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@aranacakyer", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@aranacakveri", SqlDbType.NVarChar, 30);
            // Parametreler Değişkenlere Atanır.
            cmd.Parameters["@tabloadi"].Value = tabloadi;
            cmd.Parameters["@aranacakyer"].Value = aranacakyer;
            cmd.Parameters["@aranacakveri"].Value = aranacakveri;
            conn.Open();
            DataTable dTable = new DataTable();
            //SELECT * FROM ayakkabi WHERE barkod=@barkod
            // select* from ayakkabi inner join fiyatbilgi on(ayakkabi.barkod = fiyatbilgi.barkod)
            using (SqlDataAdapter dAdapter = new SqlDataAdapter(" select* from urun Where barkod=@barkod",  conn))
                {
                    dAdapter.SelectCommand.Parameters.AddWithValue("@barkod", guna2TextBox1.Text);
                   dAdapter.Fill(dTable);
                }          
            if (dTable.Rows.Count > 0)
            {
                
                gunaDataGridView2.Rows.Add(dTable.Rows[0]["barkod"],
                    dTable.Rows[0]["urunadi"],       
                      dTable.Rows[0]["stokadedi"],
                      dTable.Rows[0]["satisfiyat"]);              
             // veri tabanından foto çekme gösterme          
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds, "urun");
                int count = ds.Tables["urun"].Rows.Count;
                if (count > 0)
                {
                    var data = (Byte[])ds.Tables["urun"].Rows[count - 1]["img"];
                    var stream = new MemoryStream(data);
                    pictureBox5.Image = Image.FromStream(stream);
                   
                }
            }
            conn.Close();
            if (checkBox1.Checked)
            {
                //illa bişeymi yapması lazım bilader 
            }
            else
            {
                System.Threading.Thread.Sleep(20);
                SystemSounds.Beep.Play();

              //  guna2TextBox1.Clear();
                //guna2TextBox1.Focus();
            }
         
     
        }


        public int fiyat;
        private void Guna2TextBox1_TextChanged(object sender, EventArgs e)// floata çeviremiyorum 
        {
            ara("urun", "barkod", guna2TextBox1.Text);
         //   ara("urun", "barkod", guna2TextBox1.Text);
           float toplam = 0;
            for (int i = 0; i < gunaDataGridView2.Rows.Count; i++)
            {
                toplam += Convert.ToInt32(gunaDataGridView2.Rows[i].Cells["Column9"].Value);
                fiyat =  Convert.ToInt32 (toplam);
            }
            label37.Text = toplam.ToString()+ "₺";
           
        }


     
       public void satısekle()
        {
            SqlConnection deneme = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");

            for (int i = 0; i < gunaDataGridView2.Rows.Count - 1; i++)
            {
                deneme.Open();
                SqlCommand komut = new SqlCommand("insert into satislar (barkod,urunadi,satisfiyat,musteriadi,musterisoyadi,satistarih,telno,ödemetipi)values(@barkod,@urunadi,@satisfiyat,@musteriadi,@musterisoyadi,@satistarih,@telno,@ödemetipi)", deneme);
                komut.Parameters.AddWithValue("@barkod", gunaDataGridView2.Rows[i].Cells["Column10"].Value.ToString());
                komut.Parameters.AddWithValue("@urunadi", gunaDataGridView2.Rows[i].Cells["Column1"].Value.ToString());
                komut.Parameters.AddWithValue("@satisfiyat", gunaDataGridView2.Rows[i].Cells["Column9"].Value);
                komut.Parameters.AddWithValue("@satistarih", label38.Text.ToString());
                komut.Parameters.AddWithValue("@musteriadi", guna2TextBox18.Text);
                komut.Parameters.AddWithValue("@musterisoyadi", guna2TextBox19.Text);
                komut.Parameters.AddWithValue("@telno", guna2TextBox20.Text);
                komut.Parameters.AddWithValue("@ödemetipi", guna2ComboBox8.SelectedItem);
                komut.ExecuteNonQuery();
                deneme.Close();
                
                
            }
            MessageBox.Show("Satış Başarılı");
            gunaDataGridView2.Rows.Clear();
            label37.Text = "0,00₺";

        }
        public void texboxtemizle()
        {
            guna2TextBox18.Clear();
            guna2TextBox19.Clear();
            guna2TextBox20.Clear();
        }
        
        public void ayakkabioku(ref string b2, ref string b3, ref string b4, ref string b5, ref string b6, ref string b7)// bazen hatalı
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                using (SqlCommand cmd = new SqlCommand("SELECT * From ayakkabi where barkod=(" + seciliveri1 + ")"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        b2 = sdr["barkod"].ToString();
                        b3 = sdr["urunadi"].ToString();
                        b4 = sdr["stokadedi"].ToString();

                    }
                    cn.Close();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT * From fiyatbilgi where barkod=(" + seciliveri1 + ")"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        b5 = sdr["alisfiyat"].ToString();
                        b6 = sdr["karoran"].ToString();
                        b7 = sdr["satisfiyat"].ToString();

                    }
                    cn.Close();
               
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void ayakkabiguncelle(string ya, string yb, string yc, string yd, string ye) 
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                baglanti.Open();
                string kayit = "update ayakkabi set urunadi=@urunadi,stokadedi=@stokadedi where barkod = (" + seciliveri1 + ")";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@urunadi", ya);
                komut.Parameters.AddWithValue("@stokadedi", yb);
                komut.ExecuteNonQuery();
                baglanti.Close();
                using (SqlCommand cmd = new SqlCommand("update fiyatbilgi set alisfiyat=@alisfiyat,karoran=@karoran,satisfiyat=@satisfiyat  where barkod=(" + seciliveri1 + ")"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = baglanti;
                    baglanti.Open();
                    cmd.Parameters.AddWithValue("@alisfiyat", float.Parse(yc));
                    cmd.Parameters.AddWithValue("@karoran",float.Parse( yd));
                    cmd.Parameters.AddWithValue("@satisfiyat", float.Parse(ye));
                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show("Güncelleme Başarılı");
            baglanti("select * from ayakkabi");

        }
        public void saatoku(ref string b2, ref string b3, ref string b4, ref string b5, ref string b6, ref string b7)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                using (SqlCommand cmd = new SqlCommand("SELECT * From saat where barkod=(" + seciliveri1 + ")"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        b2 = sdr["barkod"].ToString();
                        b3 = sdr["urunadi"].ToString();
                        b4 = sdr["stokadedi"].ToString();
                        b5 = sdr["alisfiyat"].ToString();
                        b6 = sdr["karoran"].ToString();
                        b7 = sdr["satisfiyat"].ToString();

                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void saatguncelle(string ya, string yb, string yc, string yd, string ye)
        {
            try
            {
                SqlConnection baglantii = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                baglantii.Open();
                string kayit = "update saat set urunadi=@urunadi,stokadedi=@stokadedi,alisfiyat=@alisfiyat,karoran=@karoran,satisfiyat=@satisfiyat where barkod = (" + seciliveri1 + ")";
                SqlCommand komut = new SqlCommand(kayit, baglantii);
                komut.Parameters.AddWithValue("@urunadi", ya);
                komut.Parameters.AddWithValue("@stokadedi", yb);
                komut.Parameters.AddWithValue("@alisfiyat", float.Parse(yc));
                komut.Parameters.AddWithValue("@karoran", float.Parse(yd));
                komut.Parameters.AddWithValue("@satisfiyat", float.Parse(ye));
                komut.ExecuteNonQuery();
                baglantii.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bir Hata alındı // satır 612");
            }
            MessageBox.Show("Güncelleme Başarılı");
            baglanti("select * from saat");

        }
        public void cuzdanoku(ref string b2, ref string b3, ref string b4, ref string b5, ref string b6, ref string b7)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                using (SqlCommand cmd = new SqlCommand("SELECT * From cuzdan where barkod=(" + seciliveri1 + ")"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        b2 = sdr["barkod"].ToString();
                        b3 = sdr["urunadi"].ToString();
                        b4 = sdr["stokadedi"].ToString();
                        b5 = sdr["alisfiyat"].ToString();
                        b6 = sdr["karoran"].ToString();
                        b7 = sdr["satisfiyat"].ToString();

                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void cuzdanguncelle(string ya, string yb, string yc, string yd, string ye)
        {
            try
            {
                SqlConnection baglantii = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                baglantii.Open();
                string kayit = "update cuzdan set urunadi=@urunadi,stokadedi=@stokadedi,alisfiyat=@alisfiyat,karoran=@karoran,satisfiyat=@satisfiyat where barkod = (" + seciliveri1 + ")";
                SqlCommand komut = new SqlCommand(kayit, baglantii);
                komut.Parameters.AddWithValue("@urunadi", ya);
                komut.Parameters.AddWithValue("@stokadedi", yb);
                komut.Parameters.AddWithValue("@alisfiyat", float.Parse(yc));
                komut.Parameters.AddWithValue("@karoran", float.Parse(yd));
                komut.Parameters.AddWithValue("@satisfiyat", float.Parse(ye));
                komut.ExecuteNonQuery();
                baglantii.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Hata alındı // satır 661");
            }
            MessageBox.Show("Güncelleme Başarılı");
            baglanti("select * from cuzdan");

        }
        public void cantaoku(ref string b2, ref string b3, ref string b4, ref string b5, ref string b6, ref string b7)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                using (SqlCommand cmd = new SqlCommand("SELECT * From canta where barkod=(" + seciliveri1 + ")"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        b2 = sdr["barkod"].ToString();
                        b3 = sdr["urunadi"].ToString();
                        b4 = sdr["stokadedi"].ToString();
                        b5 = sdr["alisfiyat"].ToString();
                        b6 = sdr["karoran"].ToString();
                        b7 = sdr["satisfiyat"].ToString();

                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void cantaguncelle(string ya, string yb, string yc, string yd, string ye)
        {
            try
            {
                SqlConnection baglantii = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                baglantii.Open();
                string kayit = "update canta set urunadi=@urunadi,stokadedi=@stokadedi,alisfiyat=@alisfiyat,karoran=@karoran,satisfiyat=@satisfiyat where barkod = (" + seciliveri1 + ")";
                SqlCommand komut = new SqlCommand(kayit, baglantii);
                komut.Parameters.AddWithValue("@urunadi", ya);
                komut.Parameters.AddWithValue("@stokadedi", yb);
                komut.Parameters.AddWithValue("@alisfiyat", float.Parse(yc));
                komut.Parameters.AddWithValue("@karoran", float.Parse(yd));
                komut.Parameters.AddWithValue("@satisfiyat", float.Parse(ye));
                komut.ExecuteNonQuery();
                baglantii.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Hata alındı // satır 714");
            }
            MessageBox.Show("Güncelleme Başarılı");
            baglanti("select * from canta");
        }
            private void Guna2Button13_Click(object sender, EventArgs e)// ödeme ekranına geçiş 
           {
            ses();
            if (gunaDataGridView2.Rows.Count ==1)
            {
                MessageBox.Show("Lütfen Barkod Okutun");
            }
             else if ((String.IsNullOrEmpty(guna2TextBox18.Text)) || (String.IsNullOrEmpty(guna2TextBox19.Text)) || (String.IsNullOrEmpty(guna2TextBox20.Text)))
            {
                MessageBox.Show("Lütfen Müşteri Adı Soyadı ve Telefon Numarası Giriniz!");

            }
            else
            {

                Form5 f5 = new Form5();
                f5.ShowDialog();             
                pictureBox5.Image = null;
            }
           }
        private void Guna2Button14_Click(object sender, EventArgs e)// ürün eksiltme olması lazım
        {
            ses();
            if (gunaDataGridView2.SelectedRows.Count > 0)
                {
                    gunaDataGridView2.Rows.RemoveAt(gunaDataGridView2.SelectedRows[0].Index);
                int cikarma = 0;
                for (int i = 0; i < gunaDataGridView2.Rows.Count; i++)
                {
                    cikarma -= Convert.ToInt32(gunaDataGridView2.Rows[i].Cells["Column9"].Value);
                }
                
                label37.Text = cikarma.ToString() + "₺";
            }
                else
                {
                    MessageBox.Show("Lüffen Çıkarılacak Ürünü Tablodan Seçiniz!");
                }
        }
        private void Guna2Button4_Click_1(object sender, EventArgs e)// iade yada rapordan birisi
        {
            ses();
            Form13 f13 = new Form13();
            f13.ShowDialog();
          




        }
            private void Guna2Button16_Click(object sender, EventArgs e)//Ayakkabı sil
        {
            ses();
            SqlConnection con1 = new SqlConnection("Server = localhost; Database =ayakkabistok; Integrated Security = SSPI;"); // Veritabanına Bağlanılmasını Sağlar.
            con1.Open();
            SqlCommand komut1 = new SqlCommand("delete from fiyatbilgi where barkod='" + gunaDataGridView1.CurrentRow.Cells["barkod"].Value.ToString() + "'", con1);
            komut1.ExecuteNonQuery();
            con1.Close();
            try
            {
                SqlConnection con = new SqlConnection("Server = localhost; Database =ayakkabistok; Integrated Security = SSPI;"); // Veritabanına Bağlanılmasını Sağlar.
                if (gunaDataGridView1.Rows.Count == 0)
                { 
                    MessageBox.Show("Silinecek Veri Yok", "Uyarı");
                }
                else
                { 
                    con.Open(); 
                 
                    SqlCommand komut = new SqlCommand("delete from ayakkabi where barkod='" + gunaDataGridView1.CurrentRow.Cells["barkod"].Value.ToString() + "'", con);  // Veritabanına Komut Verilmesini Sağlar.
                    if (MessageBox.Show("Seçilen Veriyi Silmek İstediğinize Emin Misiniz?\n", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                        komut.ExecuteNonQuery();
                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("Silme Gerçekleşmedi..");
                        con.Close();
                    }
                }
                baglanti("Select * from ayakkabi"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Guna2Button17_Click(object sender, EventArgs e)//saati sil
        {
            try
            {
                SqlConnection con = new SqlConnection("Server = localhost; Database =ayakkabistok; Integrated Security = SSPI;"); // Veritabanına Bağlanılmasını Sağlar.
                if (gunaDataGridView1.Rows.Count == 0)
                { 
                    MessageBox.Show("Silinecek Veri Yok", "Uyarı");
                }
                else
                { 
                    con.Open(); 
                    SqlCommand komut = new SqlCommand("delete from saat where barkod='" + gunaDataGridView1.CurrentRow.Cells["barkod"].Value.ToString() + "'", con);  // Veritabanına Komut Verilmesini Sağlar.
                    if (MessageBox.Show("Seçilen Veriyi Silmek İstediğinize Emin Misiniz?\n", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {                     
                        komut.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Silme Gerçekleşmedi..");
                        con.Close();
                    }
                }
                baglanti("Select * from saat");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Guna2Button18_Click(object sender, EventArgs e)//cüzdan sil
        {
            try
            {
                SqlConnection con = new SqlConnection("Server = localhost; Database =ayakkabistok; Integrated Security = SSPI;"); // Veritabanına Bağlanılmasını Sağlar.
                if (gunaDataGridView1.Rows.Count == 0)
                { 
                    MessageBox.Show("Silinecek Veri Yok", "Uyarı");
                }
                else
                { 
                    con.Open(); 
                    SqlCommand komut = new SqlCommand("delete from cuzdan where barkod='" + gunaDataGridView1.CurrentRow.Cells["barkod"].Value.ToString() + "'", con);  // Veritabanına Komut Verilmesini Sağlar.
                    if (MessageBox.Show("Seçilen Veriyi Silmek İstediğinize Emin Misiniz?\n", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {                        
                        komut.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Silme Gerçekleşmedi..");
                        con.Close();
                    }
                }
                baglanti("Select * from cuzdan"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Guna2Button19_Click(object sender, EventArgs e)//cantasil
        {
            try
            {
                SqlConnection con = new SqlConnection("Server = localhost; Database =ayakkabistok; Integrated Security = SSPI;"); // Veritabanına Bağlanılmasını Sağlar.
                if (gunaDataGridView1.Rows.Count == 0)
                { // Eğer Ana Tablonun İçinde Veri Yoksa Aşağıdaki Uyarıyı Ekrana Getir.
                    MessageBox.Show("Silinecek Veri Yok", "Uyarı");
                }
                else
                { // Ana Tablonun İçinde Veri Varsa Aşağıdaki İşlemleri Yaparak Verileri Sil.
                    con.Open(); // Veritabanına Bağlanır.
                    SqlCommand komut = new SqlCommand("delete from canta where barkod='" + gunaDataGridView1.CurrentRow.Cells["barkod"].Value.ToString() + "'", con);  // Veritabanına Komut Verilmesini Sağlar.
                    if (MessageBox.Show("Seçilen Veriyi Silmek İstediğinize Emin Misiniz?\n", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //komut1.ExecuteNonQuery();
                        komut.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Silme Gerçekleşmedi..");
                        con.Close();
                    }
                }
                baglanti("Select * from canta"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Guna2Button20_Click(object sender, EventArgs e)//ayakkabı güncelle
        {
            ses();
            ayakkabiguncelle a1 = new ayakkabiguncelle();
            a1.ShowDialog();
        }
        private void Guna2Button22_Click(object sender, EventArgs e)//çanta güncelle
        {
            cantaguncelle c1 = new cantaguncelle();
            c1.ShowDialog();

        }
        private void Guna2Button21_Click(object sender, EventArgs e)//cüzdan güncelle
        {
            cüzdanguncelle c2 = new cüzdanguncelle();
            c2.ShowDialog();
        }
        private void Guna2Button15_Click(object sender, EventArgs e)//saat güncelle
        {
            saatguncelle s1 = new saatguncelle();
            s1.ShowDialog();
        }

        private void Guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button23_Click(object sender, EventArgs e)
        {
            ses();
            Form10 f10 = new Form10();
            f10.ShowDialog();
        }
        public void vyedek(string path)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                if (path == string.Empty)
                {
                    MessageBox.Show("Lütfen Backup Dosyasının Kaydedileceği Yeri Seçiniz.");
                }
                else
                {
                    string cmd = "BACKUP DATABASE ayakkabistok TO DISK='" + path + "\\" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm") + ".bak'";
                    using (SqlCommand command = new SqlCommand(cmd, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Open();
                        }
                        command.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Veritabanı Başarılı Bir Şekilde Yedeklendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void vyedektendon(string path)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
                if (path == string.Empty)
                {
                    MessageBox.Show("Lütfen Geri Yüklemek İstediğiniz Yedek Dosyasını Seçiniz.");
                }
                else
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    try
                    {
                        string sqlStmt2 = string.Format("ALTER DATABASE ayakkabistok SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                        SqlCommand bu2 = new SqlCommand(sqlStmt2, conn);
                        bu2.ExecuteNonQuery();

                        string sqlStmt3 = "USE MASTER RESTORE DATABASE ayakkabistok FROM DISK = '" + path + "' WITH REPLACE";
                        SqlCommand bu3 = new SqlCommand(sqlStmt3, conn);
                        bu3.ExecuteNonQuery();

                        string sqlStmt4 = string.Format("ALTER DATABASE ayakkabistok SET MULTI_USER");
                        SqlCommand bu4 = new SqlCommand(sqlStmt4, conn);
                        bu4.ExecuteNonQuery();

                        MessageBox.Show("Veritabanı Başarılı Bir Şekilde Geri Yüklendi!");
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button24_Click(object sender, EventArgs e)
        {
            ses();
            Form11 form11 = new Form11();
            form11.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.ShowDialog();
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              
                guna2TextBox1.Clear();
                guna2TextBox1.Focus();
            }
        }

        private void guna2Button25_Click(object sender, EventArgs e)
        {
            ses();
            Form13 f13 = new Form13();
            f13.ShowDialog();
        }

        private void guna2ComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button26_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Barkodları tablodan çift tıklayarak seçiniz ve ekleyiniz", "Bilgilenidirme mesajı");
            Form14 f14 = new Form14();
            f14.Show();
        }

        private void gunaDataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(seciliveri1+" Barkodu Eklendi");
            Zen.Barcode.Code128BarcodeDraw brc = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
       //     ((Form14)Application.OpenForms["Form14"]).pictureBox1.Image = brc.Draw(seciliveri1, 100);
            for (int i=1;i<19;i++)
            {
                if((i==1)&&(((Form14)Application.OpenForms["Form14"]).pictureBox1.Image==null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox1.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label1.Text = seciliveri1.ToString();
                    ((Form14)Application.OpenForms["Form14"]).label37.Text = seciliveri3.ToString();
                    break;
                   
                }
                else if ((i == 2) && (((Form14)Application.OpenForms["Form14"]).pictureBox2.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox2.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label2.Text = seciliveri1.ToString() ;
                 ((Form14)Application.OpenForms["Form14"]).label38.Text = seciliveri3.ToString();

                    break;
                }
                else if ((i == 3) && (((Form14)Application.OpenForms["Form14"]).pictureBox3.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox3.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label3.Text = seciliveri1.ToString();
             ((Form14)Application.OpenForms["Form14"]).label39.Text = seciliveri3.ToString();
                    break;
                }
                else if ((i == 4) && (((Form14)Application.OpenForms["Form14"]).pictureBox4.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox4.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label4.Text = seciliveri1.ToString();
                    ((Form14)Application.OpenForms["Form14"]).label40.Text = seciliveri3.ToString();


                    break;
                }
                else if ((i == 5) && (((Form14)Application.OpenForms["Form14"]).pictureBox5.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox5.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label5.Text = seciliveri1.ToString();
                   ((Form14)Application.OpenForms["Form14"]).label41.Text = seciliveri3.ToString();

                    break;
                }
                else if ((i == 6) && (((Form14)Application.OpenForms["Form14"]).pictureBox6.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox6.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label6.Text = seciliveri1.ToString();
                   ((Form14)Application.OpenForms["Form14"]).label42.Text = seciliveri3.ToString();

                    break;
                }
                else if ((i == 7) && (((Form14)Application.OpenForms["Form14"]).pictureBox7.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox7.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label7.Text = seciliveri1.ToString();
                   ((Form14)Application.OpenForms["Form14"]).label43.Text = seciliveri3.ToString();

                    break;
                }
                else if ((i == 8) && (((Form14)Application.OpenForms["Form14"]).pictureBox8.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox8.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label8.Text = seciliveri1.ToString();
                 ((Form14)Application.OpenForms["Form14"]).label44.Text = seciliveri3.ToString();

                    break;
                }
                else if ((i == 9) && (((Form14)Application.OpenForms["Form14"]).pictureBox9.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox9.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label9.Text = seciliveri1.ToString();
                   ((Form14)Application.OpenForms["Form14"]).label45.Text = seciliveri3.ToString();

                    break;
                }
                else if ((i == 10) && (((Form14)Application.OpenForms["Form14"]).pictureBox10.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox10.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label10.Text = seciliveri1.ToString();
                   ((Form14)Application.OpenForms["Form14"]).label46.Text = seciliveri3.ToString();

                    break;
                }
                else if ((i == 11) && (((Form14)Application.OpenForms["Form14"]).pictureBox11.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox11.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label11.Text = seciliveri1.ToString();
                 ((Form14)Application.OpenForms["Form14"]).label47.Text = seciliveri3.ToString();

                    break;
                }
                else if ((i == 12) && (((Form14)Application.OpenForms["Form14"]).pictureBox12.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox12.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label12.Text = seciliveri1.ToString();
                 ((Form14)Application.OpenForms["Form14"]).label48.Text = seciliveri3.ToString();
                  
                    break;
                }
                else if ((i == 13) && (((Form14)Application.OpenForms["Form14"]).pictureBox13.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox13.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label13.Text = seciliveri1.ToString();
                 ((Form14)Application.OpenForms["Form14"]).label49.Text = seciliveri3.ToString();
                
                    break;
                }
                else if ((i == 14) && (((Form14)Application.OpenForms["Form14"]).pictureBox14.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox14.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label14.Text = seciliveri1.ToString();
                   ((Form14)Application.OpenForms["Form14"]).label50.Text = seciliveri3.ToString();
                   
                    break;
                }
                else if ((i == 15) && (((Form14)Application.OpenForms["Form14"]).pictureBox15.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox15.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label15.Text = seciliveri1.ToString();
    ((Form14)Application.OpenForms["Form14"]).label51.Text = seciliveri3.ToString();
                    
                    break;
                }
                else if ((i == 16) && (((Form14)Application.OpenForms["Form14"]).pictureBox16.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox16.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label16.Text = seciliveri1.ToString();
                  ((Form14)Application.OpenForms["Form14"]).label52.Text = seciliveri3.ToString();
        
                    break;
                }
                else if ((i == 17) && (((Form14)Application.OpenForms["Form14"]).pictureBox17.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox17.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label17.Text = seciliveri1.ToString();
                  ((Form14)Application.OpenForms["Form14"]).label53.Text = seciliveri3.ToString();
                
                    break;
                }
                else if ((i == 18) && (((Form14)Application.OpenForms["Form14"]).pictureBox18.Image == null))
                {
                    ((Form14)Application.OpenForms["Form14"]).pictureBox18.Image = brc.Draw(seciliveri1, 1000);
                    ((Form14)Application.OpenForms["Form14"]).label18.Text = seciliveri1.ToString();
                   ((Form14)Application.OpenForms["Form14"]).label54.Text = seciliveri3.ToString();
                    MessageBox.Show("Barkod Alanları Doldu Lütfen Yazdırınız");
                    break;
                }
            }

            
        }

      
        private void guna2TextBox21_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server = localhost; Database = ayakkabistok; Integrated Security = SSPI;");
            conn.Open();
            SqlCommand komut = new SqlCommand("select * from ayakkabi where barkod  like '%" + guna2TextBox21.Text + "%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet dataset = new DataSet();
            da.Fill(dataset);
            gunaDataGridView1.DataSource = dataset.Tables[0];
            conn.Close();
        }
    }
}
