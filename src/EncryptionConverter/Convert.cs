using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace EncryptionConverter
{
    internal class Convert
    {
        public static void Main() {
            BiodataDB.Clear();
            FingerPrintDB.Clear();
            BiodataDBNonEncrypted.ConvertAll();
            FingerprintDBNonEncrypted.ConvertAll();
        }
    }
}
