using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLoadingProgressBar
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            loadingProgressBar1.Guncelleme = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadingProgressBar1.Guncelleme = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadingProgressBar1.Value = loadingProgressBar1.Minimum;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadingProgressBar1.Step = 50;
            loadingProgressBar1.Value = 50;
            loadingProgressBar1.Maximum = 250;
           
        }
    }
}
