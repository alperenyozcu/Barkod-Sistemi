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

namespace ShoeZone
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public string barkod;
        private void button1_Click(object sender, EventArgs e)
        {
            Zen.Barcode.Code128BarcodeDraw brc = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox1.Image = brc.Draw(guna2TextBox2.Text,3000);

            barkod = guna2TextBox2.Text;
            ((Form1)Application.OpenForms["Form1"]).olustural = barkod;
            ((Form1)Application.OpenForms["Form1"]).olusturalekle();
        }
        private void pd_printbarcode(object sender,PrintPageEventArgs e)//yazdırma 
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();

        }
        private void button2_Click(object sender, EventArgs e)// yazdır
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_printbarcode);
            pd.Print();
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
    }
}
