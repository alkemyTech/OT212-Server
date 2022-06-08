using System;
using System.Security.Cryptography;
using System.Text;

namespace OngProject.Core.Helper
{
    public static class EncryptHelper
    {
        public static string GetSHA256(string text)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            var hash = sha256.ComputeHash(encoding.GetBytes(text));
            var result = Convert.ToBase64String(hash);
            return result.Substring(0,19);
        }
    }
}
