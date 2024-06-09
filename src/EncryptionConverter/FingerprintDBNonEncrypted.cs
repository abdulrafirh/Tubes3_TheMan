using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace EncryptionConverter
{
    internal class FingerprintDBNonEncrypted : SecondaryDB
    {
        public static void ConvertAll()
        {
            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM sidik_jari", connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FingerPrintDB.Insert(reader.GetString(0), reader.GetString(1));
                        }
                    }
                }
                CloseConnection();
            }
        }
    }
}
