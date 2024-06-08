using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Biodata
    {
        public string NIK { get; set; }
        public string Nama { get; set; }
        public string Tempat_lahir { get; set; }
        public DateTime Tanggal_lahir { get; set; }
        public Bogus.DataSets.Name.Gender Gender { get; set; }
        public string Golongan_darah { get; set; }
        public string Alamat { get; set; }
        public string Agama { get; set; }
        public String Status_perkawinan { get; set; }
        public string Pekerjaan { get; set; }
        public string Kewarganegaraan { get; set; }

        public override string ToString()
        {
            return $"NIK: {NIK}\n" +
                   $"Nama: {Nama}\n" +
                   $"Tempat_lahir: {Tempat_lahir}\n" +
                   $"Tanggal_lahir: {Tanggal_lahir.ToString("yyyy-MM-dd")}\n" +
                   $"Gender: {Gender}\n" +
                   $"Golongan_darah: {Golongan_darah}\n" +
                   $"Alamat: {Alamat}\n" +
                   $"Agama: {Agama}\n" +
                   $"Status_perkawinan: {Status_perkawinan}\n" +
                   $"Pekerjaan: {Pekerjaan}\n" +
                   $"Kewarganegaraan: {Kewarganegaraan}";
        }
    }
}
