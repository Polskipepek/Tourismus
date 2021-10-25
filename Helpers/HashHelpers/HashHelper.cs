using System;
using System.Security.Cryptography;
using System.Text;

namespace Helpers.HashHelpers {
    public class HashHelper {
        public static string CreateSha256(string text, string salt) {
            using (SHA256 crypt = SHA256.Create()) {
                return GetHash(crypt, text + salt);
            }
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input) {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++) {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static bool VerifyHash(string input, string hash) {
            using (SHA256 crypt = SHA256.Create()) {
                var hashOfInput = GetHash(crypt, input);
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                return comparer.Compare(hashOfInput, hash) == 0;
            }
        }
    }
}
