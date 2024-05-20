using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string info = "Allahu akbar!";
        string selectedImagePath = "";

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "Select an Image";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                byte[] imageBytes = File.ReadAllBytes(filePath); // panggil fungsi Rayhan
                selectedImagePath = filePath;
                info = "info";
                Console.WriteLine("Selected image path: " + selectedImagePath);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {}

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!selectedImagePath.Equals(""))
            {
                pictureBox1.ImageLocation = selectedImagePath;
            }

            if (!info.Equals(""))
            {
                richTextBox1.Visible = true;
                richTextBox1.Text = info;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
