using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System;

namespace AlgorithmNamespace
{ 
    public class Algoritme
    {
        public Algoritme() { }
        public static string hw() { return "Hello World"; }
    }

    public class FingerprintProcessor
    {

        public static string bmpToBinary(string imagePath)
        {


            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException($"The file {imagePath} does not exist.");
            }
            const int threshold = 70;
            Bitmap temp = new Bitmap(imagePath);
            LockBitmap img = new LockBitmap(temp);
            img.LockBits();
            int width = img.Width;
            int height = img.Height;
            StringBuilder binaryString = new StringBuilder();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = img.GetPixel(x, y);
                    int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);

                    if (grayValue < threshold)
                    {
                        binaryString.Append('0');
                    }
                    else
                    {
                        binaryString.Append('1');
                    }
                }
            }

            img.UnlockBits();
            return binaryString.ToString();
        }

        public static string binaryToAscii(string binaryString)
        {

            int paddingLength = 8 - (binaryString.Length % 8);
            if (paddingLength != 8)
            {
                binaryString = binaryString.PadRight(binaryString.Length + paddingLength, '0');
            }

            StringBuilder asciiString = new StringBuilder();

            for (int i = 0; i < binaryString.Length; i += 8)
            {
                string byteString = binaryString.Substring(i, 8);
                int asciiCode = Convert.ToInt32(byteString, 2);
                char asciiChar = (char)asciiCode;
                asciiString.Append(asciiChar);
            }

            return asciiString.ToString();
        }
        public static string get_middle_binary(string binaryString)
        {
            int midIdx = binaryString.Length / 2;
            int startIdx = midIdx - (32 / 2);

            string midString = binaryString.Substring(startIdx, 32);
            return midString;
        }

        public static int[] badCharHeuristic(string str, int size)
        {
            int[] badChar = new int[256];
            for (int i = 0; i < 256; i++)
                badChar[i] = -1;

            for (int i = 0; i < size; i++)
                badChar[(int)str[i]] = i;

            return badChar;
        }

        public static bool bmSearch(string text, string pattern)
        {
            int textLen = text.Length;
            int patLen = pattern.Length;

            int[] badChar = badCharHeuristic(pattern, patLen);

            int s = 0;

            while (s <= (textLen - patLen))
            {
                int j = patLen - 1;

                while (j >= 0 && pattern[j] == text[s + j])
                {
                    j--;
                }
                if (j < 0)
                {
                    return true;
                }
                else
                {
                    s += Math.Max(1, j - badChar[(int)text[s + j]]);
                }
            }
            return false;
        }

        public static int[] ComputeLPS(string pattern)
        {
            int[] lps = new int[pattern.Length];
            int len = 0;
            int i = 1;
            lps[0] = 0;

            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                        len = lps[len - 1];
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }

            return lps;
        }

        public static bool kmpSearch(string text, string pattern)
        {
            int[] lps = ComputeLPS(pattern);
            int i = 0;
            int j = 0;

            while (i < text.Length)
            {
                if (pattern[j] == text[i])
                {
                    j++;
                    i++;
                }
                if (j == pattern.Length)
                {
                    return true;
                }
                else if (i < text.Length && pattern[j] != text[i])
                {
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i = i + 1;
                }
            }

            return false;
        }

        public static int longestCommonSS(string text1, string text2)
        {
            int len1 = text1.Length;
            int len2 = text2.Length;

            int[] prev = new int[len2 + 1];
            int[] cur = new int[len2 + 1];

            for (int idx2 = 0; idx2 < len2 + 1; idx2++)
            {
                cur[idx2] = 0;
            }
            for (int idx1 = 1; idx1 < len1 + 1; idx1++)
            {
                for (int idx2 = 1; idx2 < len2 + 1; idx2++)
                {
                    if (text1[idx1 - 1] == text2[idx2 - 1])
                        cur[idx2] = 1 + prev[idx2 - 1];
                    else
                        cur[idx2] = 0 + Math.Max(cur[idx2 - 1], prev[idx2]);
                }
                prev = cur;
            }
            return cur[len2];
        }

        public static string getMiddle16(string text)
        {

            int totalChars = text.Length;


            int charsPerRow = (int)Math.Sqrt(totalChars);


            int middleRowIndex = charsPerRow * (charsPerRow / 2);

            var result = new System.Text.StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                int rowIndex = middleRowIndex + i * charsPerRow;
                string middleChars = text.Substring(rowIndex + 1, 4);


                result.Append(middleChars);
            }

            return result.ToString();
        }
        public static float calculateSimilarity(string text1, string text2)
        {
            int lcs = longestCommonSS(text1, text2);
            int len1 = text1.Length;
            int len2 = text2.Length;

            return ((2.0f * lcs) / (len1 + len2)) * 100;
        }

        public static void testLCS()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string imageSource = "../willdeletelater/test.BMP";
            string folderTarget = "../Altered-Easy";
            string[] files = Directory.GetFiles(folderTarget);

            string binarySource = bmpToBinary(imageSource);
            string textSource = binaryToAscii(binarySource);
            string patternSource = getMiddle16(textSource);

            List<float> similarities = new List<float>();
            List<string> fileNames = new List<string>();
            int i = 0;
            foreach (string file in files)
            {
                string binaryTarget = bmpToBinary(file);
                string textTarget = binaryToAscii(binaryTarget);
                string patternTarget = getMiddle16(textTarget);

                float similarity = calculateSimilarity(patternSource, patternTarget);
                // append to similarities array
                similarities.Add(similarity);
                fileNames.Add(file);
                i++;
                if (i % 500 == 0)
                {
                    Console.WriteLine("Processed: " + i);
                }
                // Console.WriteLine("Similarity: " + similarity);
            }
            stopwatch.Stop();
            TimeSpan timeElapsed = stopwatch.Elapsed;
            similarities.Sort();

            // Console.WriteLine("Max Similarity: " + similarities[similarities.Count - 1]);
            for (i = 0; i < 50; i++)
            {
                Console.WriteLine("Similarity: " + similarities[similarities.Count - 1 - i]);
            }
            Console.WriteLine("Time Elapsed: " + timeElapsed);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Current Directory: " + System.IO.Directory.GetCurrentDirectory());
            string imagePath = "../willdeletelater/test.BMP";

            string binaryData = FingerprintProcessor.bmpToBinary(imagePath);
            string middleBinary = FingerprintProcessor.get_middle_binary(binaryData);

            string pattern = FingerprintProcessor.binaryToAscii(middleBinary);

            string imagePath2 = "../willdeletelater/test.BMP";

            string binary2 = FingerprintProcessor.bmpToBinary(imagePath2);
            string text = FingerprintProcessor.binaryToAscii(binary2);
            Console.WriteLine("Text: " + text);
            Console.WriteLine("Pattern: " + pattern);
            bool bmResult = FingerprintProcessor.kmpSearch(text, pattern);
            Console.WriteLine("Boyer-Moore Search Result: " + bmResult);

            bool kmpResult = FingerprintProcessor.kmpSearch(text, pattern);
            Console.WriteLine("Knuth-Morris-Pratt Search Result: " + kmpResult);


        }
    }
}