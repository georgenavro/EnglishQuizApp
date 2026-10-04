using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace English_QA.Encryption
{
    public class Encryption
    {
        public static string DoHash(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            using(var sha2 = SHA512.Create())
            {
                byte[] tmp = Encoding.UTF8.GetBytes(value);
                var hash = sha2.ComputeHash(tmp);
                return Base64Encoder(GetStringFromHash(hash));
            }
        }

        private static string GetStringFromHash(byte[] hash)
        {
            
            StringBuilder value = new StringBuilder();
            for(long i = 0;i< hash.Length;i++)
            {
                value.Append(hash[i].ToString("x2"));
              
            }
            return value.ToString().ToLower();
        }
        private static string Base64Encoder(string plainText)
        {
            var plainTextByte = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextByte);
        }
    }
}
