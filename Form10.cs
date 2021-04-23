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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog(); // Bilgisayarda Bulunan Klasör Dizinlerini Görüntülemeyi Sağlar.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gunaTextBox1.Text = dlg.SelectedPath;
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            gunaTextBox1.Text = "";
            gunaTextBox2.Text = "";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog(); // Bir Dialog Ekranı ile Dosya Seçmeyi Sağlar.
            dlg.Filter = "SQL Server database backup files|*.bak*";
            dlg.Title = "Database Restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gunaTextBox2.Text = dlg.FileName;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ((Form1)Application.OpenForms["Form1"]).vyedek(gunaTextBox1.Text);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ((Form1)Application.OpenForms["Form1"]).vyedektendon(gunaTextBox2.Text);
        }
    }
}
