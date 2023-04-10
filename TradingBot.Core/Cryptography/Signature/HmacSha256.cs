using System.Security.Cryptography;
using System.Text;

namespace TradingBot.Core.Cryptography.Signature
{
    public class HmacSha256 : ISigner
    {
        public string Sign(string text, string key)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentNullException(nameof(text));
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                hmac.ComputeHash(Encoding.UTF8.GetBytes(text));

                return Convert.ToBase64String(hmac.Hash);
            }
        }
    }
}
