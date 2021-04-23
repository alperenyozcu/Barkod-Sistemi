using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;




namespace ShoeZone
{
    public partial class Form14 : Form
    {
   
        private PrintDocument printDocument1 = new PrintDocument();

        public Form14()
        {
            InitializeComponent();
        }
      
            
    private void Form14_Load(object sender, EventArgs e)
        {
          
            guna2Button1.Text = "Barkodları Yazdır";
            guna2Button1.Click += new EventHandler(printButton_Click);
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            this.Controls.Add(guna2Button1);
        }
        void printButton_Click(object sender, EventArgs e)
        {
            
         
        }
        Bitmap memoryImage;

   /*     private void pd_printbarcode(object sender, PrintPageEventArgs e)//yazdırma 
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
            
          

        }*/
        private void printDocument1_PrintPage(System.Object sender,
          System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            /* PrintDocument pd = new PrintDocument();
             pd.PrintPage += new PrintPageEventHandler(pd_printbarcode);
             pd.Print();*/
          

            int genislik = panel1.Size.Width;
            int yukseklik = panel1.Size.Height;


            using (Bitmap bmp = new Bitmap(genislik, yukseklik))
            {
                panel1.DrawToBitmap(bmp, new Rectangle(0, 0, genislik, yukseklik));
                bmp.Save("resim.png",ImageFormat.Png);
            }

            // buraya kadar olan kısımda Panel'in resmini oluşturuyoruz.

            PrintDocument prt = new PrintDocument();
            prt.PrintPage += new PrintPageEventHandler(resmiYazdir);
            prt.Print();

        }
     
 
        void resmiYazdir(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image i = System.Drawing.Image.FromFile("resim.png");
            Point p = new Point(0, 0);
            e.Graphics.DrawImage(i, p);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
