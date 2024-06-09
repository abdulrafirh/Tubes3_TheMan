using Bogus;
using System.IO;
using System;
using WindowsFormsApp1;

namespace DatabaseFaker
{
    internal static class FakerMain
    {
        static void Main()
        {
            Randomizer.Seed = new Random(42069360);
            BiodataDB.Clear();
            FingerPrintDB.Clear();
            for (int i = 1; i < 601; i++)
            {
                var GolonganDarah = new[] { "O", "A", "B", "AB", "O+", "A+", "B+", "AB+", "O-", "A-", "B-", "AB-" };
                var Agama = new[] { "Islam", "Kristen Protestan", "Katolik", "Hindu", "Buddha", "Khonghucu", "Animisme", "Dinamisme", "Anime" };
                var StatusMenikah = new[] { "Belum Menikah", "Menikah", "Cerai" };
                var BiodataFaker = new Faker<Biodata>(locale: "id_ID")
                    .RuleFor(c => c.Gender, f => f.PickRandom<Bogus.DataSets.Name.Gender>())
                    .RuleFor(c => c.Nama, (f, c) => f.Name.FullName(c.Gender) + (f.Random.Int(0, 10) > 5 ? "" : " " + f.Name.FirstName(c.Gender)) + (f.Random.Int(0, 10) > 8 ? "" : " " + f.Name.LastName(c.Gender)))
                    .RuleFor(c => c.Tempat_lahir, f => f.Address.City())
                    .RuleFor(c => c.Tanggal_lahir, f => f.Date.Past(50, DateTime.Today.AddYears(-18)))
                    .RuleFor(c => c.NIK, (f, c) => f.Random.Int(1, 36).ToString().PadLeft(2, '0') + f.Random.Int(1, 36).ToString().PadLeft(2, '0') + f.Random.Int(1, 36).ToString().PadLeft(2, '0') + c.Tanggal_lahir.ToString("ddMMyy") + f.Random.Int(1, 18).ToString().PadLeft(4, '0'))
                    .RuleFor(c => c.Golongan_darah, f => f.PickRandom(GolonganDarah))
                    .RuleFor(c => c.Alamat, f => f.Address.FullAddress())
                    .RuleFor(c => c.Agama, f => f.PickRandom(Agama))
                    .RuleFor(c => c.Status_perkawinan, f => f.PickRandom(StatusMenikah))
                    .RuleFor(c => c.Pekerjaan, f => f.Name.JobTitle())
                    .RuleFor(c => c.Kewarganegaraan, f => f.Address.Country())
                ;
                var test = BiodataFaker.Generate();
                BiodataDB.Insert(test);

                var fingerprints = FindFiles.GetRelativeFilePaths(Path.GetFullPath("./../../../../data/SOCOfing/Real"), i + "__*");

                foreach (var path in fingerprints)
                {
                    var alayName = AlayGenerator.Instance.makeAlay(test.Nama);
                    FingerPrintDB.Insert(path, alayName);
                }
            }
        }
    }
}
