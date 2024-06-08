﻿using System;
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
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            init_stuff();
        }

        string alg = "kmp";
        List<string> asciis;
        List<string> paths;
        string info = Algoritme.hw();
        string selectedImagePath = "";
        string prefix = "./../../../../data/SOCOfing/";

        private async void init_stuff()
        {
            int file_count = 6000;
            asciis = new List<string>();
            paths = new List<string>();

            LoadingScreen ls = new LoadingScreen(file_count);

            ls.Show();
            await Task.Run(() => init_other_stuff(ls));
            ls.Close();
            InitializeComponent();
            this.TopMost = true;
        }

        private void init_other_stuff(LoadingScreen ls)
        {
            int i = 600;
            while (i-- > 0)
            {
                List<string> image_paths = FindFiles.GetRelativeFilePaths(Path.GetFullPath("./../../../../data/SOCOfing/Real"), i + "__*");
                foreach (string path in image_paths)
                {
                    string binary = FingerprintProcessor.bmpToBinary(prefix + path);
                    string ascii = FingerprintProcessor.binaryToAscii(binary);
                    asciis.Add(ascii);
                    paths.Add(path);
                }
                ls.update_percentage(10);
            }
            i = 700;
        }

        private void ImageInputButton_Click(object sender, EventArgs e)
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

        private void SearchButton_Click(object sender, EventArgs e)
        {

            string most_similar_image_path = "";
            bool found = false;
            string pattern = FingerprintProcessor.binaryToAscii(FingerprintProcessor.bmpToBinary(selectedImagePath));

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < asciis.Count; i++)
            {
                if (this.alg=="kmp") found = FingerprintProcessor.kmpSearch(asciis[i], pattern);
                else found = FingerprintProcessor.bmSearch(asciis[i], pattern);

                if (found)
                {
                    most_similar_image_path = paths[i];
                    stopwatch.Stop();
                    break;
                }
            }

            int LCS_length = 0;
            if (!found)
            {
                for (int i = 0; i < asciis.Count; i++)
                {
                    int lcs = FingerprintProcessor.longestCommonSS(asciis[i], pattern);
                    if (lcs > LCS_length)
                    {
                        LCS_length = lcs;
                        most_similar_image_path = paths[i];
                    }
                }
                stopwatch.Stop();
            }

            string time = stopwatch.Elapsed.TotalMilliseconds.ToString("F2");
            

            string stupid_name = FingerPrintDB.Find(most_similar_image_path);
            string regex_pattern = NameRegex.convertToRegexPattern(stupid_name);
            List<string> daftar_nama = BiodataDB.AllNames();
            Biodata biodata_result = new Biodata();
            foreach (string nama in daftar_nama)
            {
                if (NameRegex.isMatch(nama, regex_pattern))
                {
                    biodata_result = BiodataDB.Find(nama);
                }
            }

            info = "Most similar find:\n" + biodata_result.ToString();
            if (!most_similar_image_path.Equals(""))
            {
                InputImage.ImageLocation = selectedImagePath;
                OutputImage.ImageLocation = prefix + most_similar_image_path;
                InputImage.SizeMode = PictureBoxSizeMode.CenterImage;
                OutputImage.SizeMode = PictureBoxSizeMode.CenterImage;
            }

            if (found)
            {
                info += "\nSimilarity: Perfect Match!!!";   
            }
            else
            {
                info += "\nSimilarity: " + (100 * LCS_length) / asciis[0].Length + "%";
            }

            richTextBox1.Visible = true;
            YourImageText.Visible = true;
            SearchResultText.Visible = true;
            PerfCounterText.Visible = true;

            richTextBox1.Text = info;
            YourImageText.SelectAll();
            YourImageText.SelectionAlignment = HorizontalAlignment.Center;
            YourImageText.Select(0, 0);

            SearchResultText.SelectAll();
            SearchResultText.SelectionAlignment = HorizontalAlignment.Center;
            SearchResultText.Select(0, 0);

            PerfCounterText.Text = "The last calculation took: " + time + " ms";
            PerfCounterText.SelectAll();
            PerfCounterText.SelectionAlignment = HorizontalAlignment.Right;
            PerfCounterText.Select(0, 0);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void AlgToggle_Click(object sender, EventArgs e)
        {
            if (this.alg == "kmp")
            {
                AlgToggle.Text = "Current Algorithm: BM\n(Click to toggle)";
                this.alg = "bm";
            } 
            else
            {
                AlgToggle.Text = "Current Algorithm: KMP\n(Click to toggle)";
                this.alg = "kmp";
            }
        }
    }
}
