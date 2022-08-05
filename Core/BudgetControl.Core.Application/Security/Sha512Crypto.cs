using System.Security.Cryptography;
using System.Text;

namespace BudgetControl.Core.Application.Security
{
    public static class Sha512Crypto
    {
        public static string Encrypt(string value)
        {
            SHA512 sha512 = SHA512.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            byte[] hash = sha512.ComputeHash(bytes);

            return GetString(hash);
        }

        private static string GetString(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}
