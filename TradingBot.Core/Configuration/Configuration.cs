namespace TradingBot.Core.Configuration
{
    public class Configuration : IConfiguration
    {
        public IApiKey ApiKey { get; }

        public Configuration(IApiKey apiKey)
        {
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));

            ApiKey = apiKey;
        }
    }
}
