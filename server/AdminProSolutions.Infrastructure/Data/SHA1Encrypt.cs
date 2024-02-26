using System.Security.Cryptography;
using System.Text;

namespace AdminProSolutions.Infrastructure.Data
{ 
    public static class SHA1Encrypt
    {
        static string plainText = string.Empty;
        static string cryptedText = string.Empty;
        static SHA1? cryptAlgorithm;
        static byte[] hashValue = Array.Empty<byte>();

        public static byte[] GetHashValue()
        {
            return hashValue;
        }
        public static string Encrypt(string text)
        {
            cryptAlgorithm = SHA1.Create();
            plainText = text;
            hashValue = cryptAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            foreach (byte b in hashValue)
            {
                cryptedText += b.ToString("X2");
            }
            return "0x" + cryptedText;
        }

        public static bool VerifyEncryption(string loginPass, byte[] hashedPass)
        {
            Encrypt(loginPass);
            return hashValue.SequenceEqual(hashedPass);
        }
    }
}
