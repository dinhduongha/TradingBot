namespace TradingBot.Core.Configuration
{
    public interface IApiKey
    {
        string Key { get; }

        string Secret { get; }
    }
}
