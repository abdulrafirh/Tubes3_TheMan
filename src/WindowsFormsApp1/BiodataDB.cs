using Bogus.DataSets;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class BiodataDB : ItemDB
    {
        public static void Insert(Biodata b) {

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Biodata VALUES (@NIK, @Nama, @Tempat_lahir, @Tanggal_lahir, @Jenis_kelamin, @Golongan_darah, @Alamat, @Agama, @Status_perkawinan, @Pekerjaan, @Kewarganegaraan)", connection);
                cmd.Parameters.AddWithValue("NIK", b.NIK);
                cmd.Parameters.AddWithValue("Nama", b.Nama);
                cmd.Parameters.AddWithValue("Tempat_lahir", b.Tempat_lahir);
                cmd.Parameters.AddWithValue("Tanggal_lahir", b.Tanggal_lahir);
                cmd.Parameters.AddWithValue("Jenis_kelamin", b.Gender == Name.Gender.Male ? "Laki-Laki" : "Perempuan");
                cmd.Parameters.AddWithValue("Golongan_darah", b.Golongan_darah);
                cmd.Parameters.AddWithValue("Alamat", b.Alamat);
                cmd.Parameters.AddWithValue("Agama", b.Agama);
                cmd.Parameters.AddWithValue("Status_perkawinan", b.Status_perkawinan.ToString());
                cmd.Parameters.AddWithValue("Pekerjaan", b.Pekerjaan);
                cmd.Parameters.AddWithValue("Kewarganegaraan", b.Kewarganegaraan);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public static Biodata Find(string nama)
        {
            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Biodata WHERE nama = @Nama", connection))
                {
                    cmd.Parameters.AddWithValue("@Nama", nama);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            CloseConnection();
                            return new Biodata
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
                            };
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

        public static void Clear() {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM biodata", connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }
    }
}
