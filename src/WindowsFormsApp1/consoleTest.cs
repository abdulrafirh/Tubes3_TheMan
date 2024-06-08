using AlgorithmNamespace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal static class consoleTest
    {
        static void Main()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<String> binaries = new List<String>();
            List<String> paths = new List<String>();
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
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}
