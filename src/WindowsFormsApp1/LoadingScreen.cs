using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoadingScreen : Form
    {
        int percentage, done_count, total;
        public LoadingScreen(int total)
        {
            percentage = 0;
            done_count = 0;
            this.total = total;
            InitializeComponent();
            this.pictureBox1.ImageLocation = "./../../../asset/mikuloading.gif";
            this.TopMost = true;
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "Loading Fingerprints...\n";
            this.richTextBox1.SelectAll();
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        public void update_percentage(int done_increment = 1)
        {
            done_count += done_increment;
            this.percentage = (100*this.done_count) / this.total;

            string temp = "Loading Fingerprints...\n";
            temp += done_count.ToString();
            temp += "/";
            temp += total.ToString();
            temp += " images done ";
            temp += "(" + this.percentage.ToString() + "%)";

            if (this.richTextBox1.InvokeRequired)
            {
                this.richTextBox1.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.richTextBox1.Text = temp;
                });
            }
            else this.richTextBox1.Text = temp;
        }

        private void LoadingScreen_FromClosing(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
