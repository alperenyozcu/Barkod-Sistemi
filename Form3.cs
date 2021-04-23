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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.Items.Add("Erkek");
            guna2ComboBox1.Items.Add("Kadın");
            guna2ComboBox1.Items.Add("Çocuk");
            guna2ComboBox1.Items.Add("Terlik");

        }
    }
}
