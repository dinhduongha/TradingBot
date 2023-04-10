namespace TradingBot.Core.Configuration
{
    public class TradingBotConfiguration : ITradingBotConfiguration
    {
        public IApiKey ApiKey { get; }

        public TradingBotConfiguration(IApiKey apiKey)
        {
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));

            ApiKey = apiKey;
        }
    }
}
