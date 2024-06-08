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
    }
}
