using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgorithmNamespace;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            init_stuff();
            Console.WriteLine("tes2");
        }

        private async void init_stuff()
        {
            int file_count = 6000;
            binaries = new List<string>();
            paths = new List<string>();

            LoadingScreen ls = new LoadingScreen(file_count);

            ls.Show();
            await Task.Run(() => init_other_stuff(ls));
            ls.Close();

        }

        private void init_other_stuff(LoadingScreen ls)
        {
            int i = 600;
            while (i-- > 0)
            {
                List<string> image_paths = FindFiles.GetRelativeFilePaths(Path.GetFullPath("./../../../../data/SOCOfing/Real"), i + "__*");
                foreach (string path in image_paths)
                {
                    string binary = FingerprintProcessor.bmpToBinary("./../../../../data/SOCOfing/" + path);
                    binaries.Add(binary);
                    paths.Add(path);
                }
                ls.update_percentage(10);
            }
            i = 700;
        }

        List<string> binaries;
        List<string> paths;
        string info = Algoritme.hw();
        string selectedImagePath = "";

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "Select an Image";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                selectedImagePath = filePath;
                Console.WriteLine("Selected image path: " + selectedImagePath);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {}

        private void button1_Click_1(object sender, EventArgs e)
        {

            bool found = false;
            string pattern = FingerprintProcessor.bmpToBinary(selectedImagePath);
            foreach (string binary in binaries)
            {
                /**
                 * 
                 * TODO: tambahin toggle buat boyer moore 
                 * 
                */
                found = FingerprintProcessor.kmpSearch(binary, pattern);
                if (found) break;
            }

            string most_similar_image_path = "";
            int LCS_length = 0;
            if (!found)
            {
                for (int i = 0; i < binaries.Count; i++)
                {
                    int lcs = FingerprintProcessor.longestCommonSS(binaries[i], pattern);
                    if (lcs > LCS_length)
                    {
                        LCS_length = lcs;
                        most_similar_image_path = paths[i];
                    }
                }
            }

            if (found)
            {
                if (!selectedImagePath.Equals(""))
                {
                    pictureBox1.ImageLocation = selectedImagePath;
                }
                info = "Found!";
                
            }
            else
            {
                info = "Not found!";
            }

            richTextBox1.Visible = true;
            richTextBox1.Text = info;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }
    }
}
