using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;
using MySql.Data.MySqlClient;

namespace EncryptionConverter
{
        public class BiodataDBNonEncrypted : SecondaryDB
        {
            public static void ConvertAll()
            {
                if (OpenConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM biodata", connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BiodataDB.Insert(new Biodata
                                {
                                    NIK = reader.GetString("NIK"),
                                    Nama = reader.GetString("nama"),
                                    Tempat_lahir = reader.IsDBNull(2) ? null : reader.GetString("tempat_lahir"),
                                    Tanggal_lahir = reader.IsDBNull(3) ? new DateTime() : reader.GetDateTime("tanggal_lahir"),
                                    Gender = reader.GetString("jenis_kelamin") == "Laki-Laki" ? Bogus.DataSets.Name.Gender.Male : Bogus.DataSets.Name.Gender.Female,
                                    Golongan_darah = reader.IsDBNull(5) ? null : reader.GetString("golongan_darah"),
                                    Alamat = reader.IsDBNull(6) ? null : reader.GetString("alamat"),
                                    Agama = reader.IsDBNull(7) ? null : reader.GetString("agama"),
                                    Status_perkawinan = reader.GetString("status_perkawinan"),
                                    Pekerjaan = reader.IsDBNull(8) ? null : reader.GetString("pekerjaan"),
                                    Kewarganegaraan = reader.IsDBNull(9) ? null : reader.GetString("kewarganegaraan"),
                                });
                            }
                        }
                    }
                    CloseConnection();
                }
            }
        }
}
