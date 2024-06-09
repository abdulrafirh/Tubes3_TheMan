using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Okamoto-Uchiyama Encryption
 */
namespace WindowsFormsApp1
{
    internal class Encryption
    {
        private BigInteger p;
        private BigInteger q;
        private BigInteger n;
        private BigInteger g;
        private BigInteger h;
        private bool keyGenerated = false;

        private static Encryption globalInstance;

        public static Encryption getGlobalInstance() {
            if (globalInstance == null) {
                globalInstance = new Encryption(new System.Numerics.BigInteger(80702033281), new System.Numerics.BigInteger(93979336877));
            }
                
            return globalInstance;
        }
        public Encryption(BigInteger p, BigInteger q) { 
            this.p = p;
            this.q = q;
        }

        public Tuple<BigInteger, BigInteger, BigInteger> getPublicKey()
        {
            if (!keyGenerated)
            {
                n = p * p * q;
                g = 580582654;
                h = BigInteger.ModPow(g, n, n);
                keyGenerated = true;
            }
            return new Tuple<BigInteger, BigInteger, BigInteger>(n, g, h);
        }

        public Tuple<BigInteger, BigInteger, BigInteger> generatePublicKey() {
            if (!keyGenerated)
            {
                n = p * p * q;
                g = FindG(n, p);
                h = BigInteger.ModPow(g, n, n);
                keyGenerated = true;
            }
            return new Tuple<BigInteger, BigInteger, BigInteger> (n, g, h);
        }

        public BigInteger Encrypt(BigInteger m)
        {
            if (!keyGenerated) {
                getPublicKey();
            }

            Random random = new Random();
            BigInteger r = new BigInteger(random.Next(1, n > 2147483647 ? 2147483647 : (int)n));

            BigInteger g_exp_m = BigInteger.ModPow(g, m, n);
            BigInteger h_exp_r = BigInteger.ModPow(h, r, n);
            BigInteger c = (g_exp_m * h_exp_r) % n;
            return c;
        }

        public byte[] EncryptBytes(byte[] bytes) {
            if (!keyGenerated)
            {
                getPublicKey();
            }

            bytes = bytes.Append((byte)0).ToArray();
            BigInteger m = new BigInteger(bytes);

            Random random = new Random();
            BigInteger r = new BigInteger(random.Next(1, n > 2147483647 ? 2147483647 : (int)n));

            BigInteger g_exp_m = BigInteger.ModPow(g, m, n);
            BigInteger h_exp_r = BigInteger.ModPow(h, r, n);
            BigInteger c = (g_exp_m * h_exp_r) % n;
            return c.ToByteArray();
        }

        public byte[] EncryptLongBytes(byte[] bytes)
        {
            if (!keyGenerated)
            {
                getPublicKey();
            }

            List<BigInteger> encryptedChunks = new List<BigInteger>();
            int chunkSize = p.ToByteArray().Length - 1;

            for (int i = 0; i < bytes.Length; i += chunkSize)
            {
                int remainingBytes = bytes.Length - i;
                int chunkLength = Math.Min(chunkSize, remainingBytes);
                byte[] chunk = new byte[chunkLength + 1];
                Array.Copy(bytes, i, chunk, 0, chunkLength);
                chunk[chunkLength] = (byte)0;

                BigInteger message = new BigInteger(chunk);

                BigInteger encryptedChunk = Encrypt(message);
                encryptedChunks.Add(encryptedChunk);
            }

            byte[] encryptedBytes = CombineBigIntegersToEncryptedBytes(encryptedChunks);
            return encryptedBytes;
        }

        private static byte[] CombineBigIntegersToEncryptedBytes(List<BigInteger> bigInts)
        {
            List<byte> byteList = new List<byte>();
            foreach (BigInteger bigInt in bigInts)
            {
                byte[] chunkBytes = bigInt.ToByteArray();
                byteList.AddRange(chunkBytes);

                if (chunkBytes.Length != 14) {
                    for (int i = 0; i < 14 - chunkBytes.Length; i++) {
                        byteList.Add(0);
                    }
                }
            }
            return byteList.ToArray();
        }
        private static byte[] CombineBigIntegersToBytes(List<BigInteger> bigInts)
        {
            List<byte> byteList = new List<byte>();
            foreach (BigInteger bigInt in bigInts)
            {
                byte[] chunkBytes = bigInt.ToByteArray();
                chunkBytes = RemoveTrailingZerosLoop(chunkBytes);
                byteList.AddRange(chunkBytes);
            }
            return byteList.ToArray();
        }

        public static byte[] AddPadding(byte[] data, int targetLength, byte paddingValue = 0)
        {
            int paddingSize = targetLength - data.Length;
            byte[] paddedData = new byte[targetLength];
            Array.Copy(data, 0, paddedData, 0, data.Length);

            for (int i = data.Length; i < targetLength; i++)
            {
                paddedData[i] = paddingValue;
            }
            return paddedData;
        }

        private static byte[] RemoveTrailingZerosLoop(byte[] data)
        {
            int nonZeroCount = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != 0)
                {
                    nonZeroCount++;
                }
            }

            byte[] trimmedArray = new byte[nonZeroCount];
            int index = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != 0)
                {
                    trimmedArray[index++] = data[i];
                }
            }

            return trimmedArray;
        }

        public BigInteger Decrypt(BigInteger c)
        {

            if (!keyGenerated)
            {
                getPublicKey();
            }

            BigInteger a = (BigInteger.ModPow(c, p - 1, BigInteger.Pow(p, 2)) - 1) / p;
            BigInteger b = (BigInteger.ModPow(g, p - 1, BigInteger.Pow(p, 2)) - 1) / p;

            BigInteger invB;
            (_, invB, _) = ExtendedEuclideanAlgorithm(b, p);

            BigInteger m = (a * invB) % p;
            if (m < 0) { m += p; }
            return m;
        }

        public byte[] DecryptBytes(byte[] bytes) {
            if (!keyGenerated)
            {
                getPublicKey();
            }

            bytes = bytes.Append((byte)0).ToArray();
            BigInteger c = new BigInteger(bytes);

            BigInteger a = (BigInteger.ModPow(c, p - 1, BigInteger.Pow(p, 2)) - 1) / p;
            BigInteger b = (BigInteger.ModPow(g, p - 1, BigInteger.Pow(p, 2)) - 1) / p;

            BigInteger invB;
            (_, invB, _) = ExtendedEuclideanAlgorithm(b, p);

            BigInteger m = (a * invB) % p;
            if (m < 0) { m += p; }
            return m.ToByteArray();
        }
        public byte[] DecryptLongBytes(byte[] bytes)
        {
            if (!keyGenerated)
            {
                getPublicKey();
            }

            List<BigInteger> decryptedChunks = new List<BigInteger>();
            int chunkSize = 14;

            for (int i = 0; i < bytes.Length; i += chunkSize)
            {
                byte[] chunk = new byte[chunkSize];
                Array.Copy(bytes, i, chunk, 0, chunkSize);

                BigInteger encryptedChunk = new BigInteger(chunk);

                BigInteger decryptedChunk = Decrypt(encryptedChunk);
                decryptedChunks.Add(decryptedChunk);
            }

            byte[] decryptedBytes = CombineBigIntegersToBytes(decryptedChunks);
            return decryptedBytes;
        }

        public string EncryptString(string m) {
            byte[] bytes = Encoding.UTF8.GetBytes(m);
            byte[] encryptedBytes = EncryptLongBytes(bytes);
            string result = Convert.ToBase64String(encryptedBytes);
            return result;
        }

        public string DecryptString(string c)
        {
            byte[] bytes = Convert.FromBase64String(c);
            byte[] decryptedBytes = DecryptLongBytes(bytes);
            string result = Encoding.UTF8.GetString(decryptedBytes);
            return result;
        }

        public string EncryptDateTime(DateTime dateTime)
        {
            string dateTimeString = dateTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string encryptedData = EncryptString(dateTimeString);
            return encryptedData;
        }

        public DateTime DecryptDateTime(string encryptedString)
        {
            string decryptedString = DecryptString(encryptedString);
            return DateTime.Parse(decryptedString);
        }

        private static Tuple<BigInteger, BigInteger, BigInteger> ExtendedEuclideanAlgorithm(BigInteger a, BigInteger b)
        {
            BigInteger d, x, y;
            if (a == 0)
            {
                return new Tuple<BigInteger, BigInteger, BigInteger>(b, 0, 1);
            }
            else
            {
                (d, y, x) = ExtendedEuclideanAlgorithm(b % a, a);
                return new Tuple<BigInteger, BigInteger, BigInteger>(d, x - (b / a) * y, y);
            }
        }

        private static BigInteger FindG(BigInteger n, BigInteger p)
        {
            Random random = new Random();
            while (true)
            {
                int g = random.Next(2, n > 2147483647 ? 2147483647 : (int)n);
                if (GCD(g, p) == 1 && BigInteger.ModPow(g, p - 1, p * p) != 1)
                {
                    return g;
                }
            }
        }

        private static bool IsPrime(BigInteger num)
        {
            if (num <= 1) return false;
            if (num <= 3) return true;
            if (num % 2 == 0 || num % 3 == 0) return false;

            for (int i = 5; i * i <= num; i += 6)
            {
                if (num % i == 0 || num % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
