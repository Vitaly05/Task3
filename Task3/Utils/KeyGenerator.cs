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
            var f = RandomNumberGenerator.Create();
            var s = new byte[32];
            f.GetBytes(s);
            Key = Convert.ToHexString(s);
        }
    }
}
