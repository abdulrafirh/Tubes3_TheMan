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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO biodata VALUES (@NIK, @Nama, @Tempat_lahir, @Tanggal_lahir, @Jenis_kelamin, @Golongan_darah, @Alamat, @Agama, @Status_perkawinan, @Pekerjaan, @Kewarganegaraan)", connection);
                cmd.Parameters.AddWithValue("NIK", Encryption.getGlobalInstance().EncryptString(b.NIK));
                cmd.Parameters.AddWithValue("Nama", Encryption.getGlobalInstance().EncryptString(b.Nama));
                cmd.Parameters.AddWithValue("Tempat_lahir", Encryption.getGlobalInstance().EncryptString(b.Tempat_lahir));
                cmd.Parameters.AddWithValue("Tanggal_lahir", Encryption.getGlobalInstance().EncryptDateTime(b.Tanggal_lahir));
                cmd.Parameters.AddWithValue("Jenis_kelamin", b.Gender == Name.Gender.Male ? "Laki-Laki" : "Perempuan");
                cmd.Parameters.AddWithValue("Golongan_darah", Encryption.getGlobalInstance().EncryptString(b.Golongan_darah));
                cmd.Parameters.AddWithValue("Alamat", Encryption.getGlobalInstance().EncryptString(b.Alamat));
                cmd.Parameters.AddWithValue("Agama", Encryption.getGlobalInstance().EncryptString(b.Agama));
                cmd.Parameters.AddWithValue("Status_perkawinan", b.Status_perkawinan.ToString());
                cmd.Parameters.AddWithValue("Pekerjaan", Encryption.getGlobalInstance().EncryptString(b.Pekerjaan));
                cmd.Parameters.AddWithValue("Kewarganegaraan", Encryption.getGlobalInstance().EncryptString(b.Kewarganegaraan));
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public static Biodata Find(string nama)
        {
            List<Biodata> biodatas = All();
            foreach (var biodata in biodatas)
            {
                if (biodata.Nama == nama) { 
                    return biodata;
                }
            }
            return null;
        }

        public static List<Biodata> All()
        {
            List<Biodata> biodata = new List<Biodata>();

            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM biodata", connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            biodata.Add(new Biodata
                            {
                                NIK = Encryption.getGlobalInstance().DecryptString(reader.GetString("NIK")),
                                Nama = Encryption.getGlobalInstance().DecryptString(reader.GetString("nama")),
                                Tempat_lahir = reader.IsDBNull(2) ? null : Encryption.getGlobalInstance().DecryptString(reader.GetString("tempat_lahir")),
                                Tanggal_lahir = reader.IsDBNull(3) ? new DateTime() : Encryption.getGlobalInstance().DecryptDateTime(reader.GetString("tanggal_lahir")),
                                Gender = reader.GetString("jenis_kelamin") == "Laki-Laki" ? Bogus.DataSets.Name.Gender.Male : Bogus.DataSets.Name.Gender.Female,
                                Golongan_darah = reader.IsDBNull(5) ? null : Encryption.getGlobalInstance().DecryptString(reader.GetString("golongan_darah")),
                                Alamat = reader.IsDBNull(6) ? null : Encryption.getGlobalInstance().DecryptString(reader.GetString("alamat")),
                                Agama = reader.IsDBNull(7) ? null : Encryption.getGlobalInstance().DecryptString(reader.GetString("agama")),
                                Status_perkawinan = reader.GetString("status_perkawinan"),
                                Pekerjaan = reader.IsDBNull(8) ? null : Encryption.getGlobalInstance().DecryptString(reader.GetString("pekerjaan")),
                                Kewarganegaraan = reader.IsDBNull(9) ? null : Encryption.getGlobalInstance().DecryptString(reader.GetString("kewarganegaraan")),
                            });
                        }
                    }
                }
                CloseConnection();
            }
            return biodata;
        }

        public static List<string> AllDecryptedNama()
        {
            List<string> nama = new List<string>();

            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT nama FROM biodata", connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nama.Add(Encryption.getGlobalInstance().DecryptString(reader.GetString(0)));
                        }
                    }
                }
                CloseConnection();
            }
            return nama;
        }

        public static List<string> AllNames()
        {
            return AllDecryptedNama();
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
