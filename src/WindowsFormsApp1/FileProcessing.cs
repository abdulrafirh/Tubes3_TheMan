using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class FindFiles
    {
        public static string GetRelativePath(string relativeTo, string path)
        {
            var uri = new Uri(relativeTo);
            var rel = Uri.UnescapeDataString(uri.MakeRelativeUri(new Uri(path)).ToString()).Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            if (rel.Contains(Path.DirectorySeparatorChar.ToString()) == false)
            {
                rel = $".{Path.DirectorySeparatorChar}{rel}";
            }
            return rel;
        }
        public static List<string> GetRelativeFilePaths(string directoryPath, string searchPattern)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                throw new ArgumentNullException(nameof(directoryPath));
            }

            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException($"Directory not found: {directoryPath}");
            }

            List<string> relativePaths = new List<string>();

            foreach (string filePath in Directory.EnumerateFiles(directoryPath, searchPattern))
            {
                // Get the relative path from the base directory
                string relativePath = GetRelativePath(directoryPath, filePath);
                relativePaths.Add(relativePath);
            }

            return relativePaths;
        }
    }
}
