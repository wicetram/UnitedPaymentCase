using System.Security.Cryptography;
using System.Text;

namespace UnitedPaymentCaseCore.Util.Hash
{
    public static class AESCrypto
    {
        public static string CreateHash(string hashString)
        {

            SHA512 s512 = SHA512.Create();

            var ByteConverter = new UnicodeEncoding();

            byte[] bytes = s512.ComputeHash(ByteConverter.GetBytes(hashString));

            var hash = BitConverter.ToString(bytes).Replace("-", "");

            return hash;
        }
    }
}
