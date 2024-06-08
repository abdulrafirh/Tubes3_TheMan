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
                cmd.Parameters.AddWithValue("berkas_citra", berkas_citra);
                cmd.Parameters.AddWithValue("nama", nama);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public static string Find(string berkas_citra)
        {
            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT nama FROM sidik_jaki WHERE berkas_citra = @berkas_citra", connection))
                {
                    cmd.Parameters.AddWithValue("@berkas_citra", berkas_citra);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            CloseConnection();
                            return reader.GetString(0);
                        }
                        else
                        {
                            CloseConnection();
                            return null;
                        }
                    }
                }
            }
            return null;
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
