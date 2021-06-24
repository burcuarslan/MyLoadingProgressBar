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
            loadingProgressBar1.Value = 0;
        }




        //private void button1_Click(object sender, EventArgs e)
        //{
        //    loadingProgressBar1.Value = 1;
        //    this.timer1.Interval = 1;
        //    this.timer1.Enabled = true;
        //}

        //private void timer1_Tick(object sender, EventArgs e)
        //{

        //    if (loadingProgressBar1.Value > 0)
        //    {
        //        ForeColor = Color.FromArgb(loadingProgressBar1.Value, 100, loadingProgressBar1.Value);
        //        loadingProgressBar1.Value++;
        //    }
        //    else
        //    {
        //        this.timer1.Enabled = false;
        //    }
        //}
    }
}
