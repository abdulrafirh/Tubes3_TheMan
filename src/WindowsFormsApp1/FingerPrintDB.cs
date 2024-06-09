using Bogus.DataSets;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class FingerPrintDB : ItemDB
    {
        public static void Insert(string berkas_citra, string nama)
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO sidik_jari VALUES (@berkas_citra, @nama)", connection);
                cmd.Parameters.AddWithValue("berkas_citra", Encryption.getGlobalInstance().EncryptString(berkas_citra));
                cmd.Parameters.AddWithValue("nama", Encryption.getGlobalInstance().EncryptString(nama));
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public static string Find(string berkas_citra)
        {
            Dictionary<String, String> map = All();
            return map[berkas_citra];
        }

        public static Dictionary<String, String> All() {
            Dictionary<String, String> result = new Dictionary<String, String>();

            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM sidik_jari", connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(Encryption.getGlobalInstance().DecryptString(reader.GetString(0)), Encryption.getGlobalInstance().DecryptString(reader.GetString(1)));
                        }
                    }
                }
                CloseConnection();
            }
            return result;
        }

        public static void Clear()
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM sidik_jari", connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }
    }
}
