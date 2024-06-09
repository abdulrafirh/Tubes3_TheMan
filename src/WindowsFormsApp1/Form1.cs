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
using System.Diagnostics;
using MySqlX.XDevAPI.Common;
using static Mysqlx.Expect.Open.Types.Condition.Types;

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
            this.TopMost = false;
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
            openFileDialog1.Filter = "Image Files|*.bmp;";
            openFileDialog1.Title = "Select an Image";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                selectedImagePath = filePath;
                Console.WriteLine("Selected image path: " + selectedImagePath);
            }

            try
            {
                var bro = new LockBitmap(new Bitmap(selectedImagePath));
                bro.LockBits(); bro.UnlockBits();

                this.InputErrorMsg.Visible = false;
                InputImage.ImageLocation = selectedImagePath;
                OutputImage.ImageLocation = "./../../../asset/catloading.gif";
                InputImage.SizeMode = PictureBoxSizeMode.CenterImage;
                OutputImage.SizeMode = PictureBoxSizeMode.CenterImage;
                OutputImage.SizeMode = PictureBoxSizeMode.StretchImage;

                SearchResultText.Text = "Waiting...";
                SearchResultText.SelectAll();
                SearchResultText.SelectionAlignment = HorizontalAlignment.Center;
                SearchResultText.Select(0,0);

                SearchResultText.Visible = true;
                YourImageText.Visible = true;
                YourImageText.SelectAll();
                YourImageText.SelectionAlignment = HorizontalAlignment.Center;
                YourImageText.Select(0, 0);
            }
            catch (System.Exception ex) {
                this.InputErrorMsg.Visible = true;
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

            
            
            SortedDictionary<float, List<int>> dict = new SortedDictionary<float, List<int>>();
            List<KeyValuePair<float, int>> top10 = new List<KeyValuePair<float, int>>();
            if (!found)
            {
                for (int i = 0; i < asciis.Count; i++)
                {
                    float similarity = FingerprintProcessor.calculateSimilarity(asciis[i], pattern);
                    if (!dict.ContainsKey(similarity))
                    {
                        dict[similarity] = new List<int>();
                    }
                    dict[similarity].Add(i);
                }
            }

            int j = 50;
            foreach (var kvp in dict.Reverse())
            {
                foreach (var index in kvp.Value)
                {
                    if (j > 0)
                    {
                        top10.Add(new KeyValuePair<float, int>(kvp.Key, index));
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            float best_similarity = -1;
            if (!found)
            {
                int best_longestSS = 0;
                for (int i = 0; i < 10; i++)
                {
                    int longestSS = FingerprintProcessor.longestCommonSS(asciis[top10[i].Value], pattern);
                    if (longestSS > best_longestSS)
                    {
                        best_longestSS = longestSS;
                        most_similar_image_path = paths[top10[i].Value];
                    }
                }
                best_similarity = (best_longestSS*100) / pattern.Length;
                stopwatch.Stop();
            }


            string time = stopwatch.Elapsed.TotalMilliseconds.ToString("F2");

            if (!found && best_similarity < 61)
            {
                info = "Couldn't find an image above 60% similarity!";
                SearchResultText.Visible = false;
                YourImageText.Visible = false;
                InputImage.Visible = false;
                OutputImage.Visible = false;
                goto NOT_SIMILAR_ENOUGH;
            }
            

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
                info += "\nSimilarity: " + best_similarity.ToString("F2") + "%";
            }

            SearchResultText.Text = "Search Result: ";
            SearchResultText.Visible = true;
            YourImageText.Visible = true;

            SearchResultText.SelectAll();
            SearchResultText.SelectionAlignment = HorizontalAlignment.Center;
            SearchResultText.Select(0, 0);

            PerfCounterText.Text = "The last calculation took: " + time + " ms";
            PerfCounterText.SelectAll();
            PerfCounterText.SelectionAlignment = HorizontalAlignment.Right;
            PerfCounterText.Select(0, 0);


            NOT_SIMILAR_ENOUGH:
            PerfCounterText.Visible = true;
            richTextBox1.Visible = true;
            richTextBox1.Text = info;
            YourImageText.SelectAll();
            YourImageText.SelectionAlignment = HorizontalAlignment.Center;
            YourImageText.Select(0, 0);

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
        
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchResultText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
