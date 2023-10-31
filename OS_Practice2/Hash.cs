using System;
using System.Text;
using System.Security.Cryptography;

namespace OS_Practice2
{
    internal static class Hash
    {
        internal static string CalculateSha256Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            using (var sha256 = new SHA256Managed())
            {
                byte[] inputData = Encoding.UTF8.GetBytes(input);
                byte[] hashResult = sha256.ComputeHash(inputData);
                return BitConverter.ToString(hashResult).Replace("-", string.Empty);
            }
        }
    }
}
