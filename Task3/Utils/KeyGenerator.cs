using System.Security.Cryptography;
using System.Text;

namespace Task3.Utils
{
    internal class KeyGenerator
    {
        public string Key { get; private set; } = "";

        public string Hmac { get; private set; } = "";

        public KeyGenerator()
        {
            generateKey();
        }

        public string GetHash(string text)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(Key);
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            using (HMACSHA256 hmac = new HMACSHA256(keyBytes))
            {
                var hash = hmac.ComputeHash(textBytes);
                return Convert.ToHexString(hash);
            }
        }

        private void generateKey()
        {
            var rng = RandomNumberGenerator.Create();
            var bytes = new byte[32];
            rng.GetBytes(bytes);
            Key = Convert.ToHexString(bytes);
        }
    }
}