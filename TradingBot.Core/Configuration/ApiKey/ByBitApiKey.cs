namespace TradingBot.Core.Configuration.Api
{
    public class ByBitApiKey : IApiKey
    {
        public string Key { get; }

        public string Secret { get; }

        public ByBitApiKey(string key, string secret)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrEmpty(secret)) throw new ArgumentNullException(nameof(secret));

            Key = key;
            Secret = secret;
        }
    }
}
