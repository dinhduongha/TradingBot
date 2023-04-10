namespace TradingBot.Core.Cryptography
{
    public interface ISigner
    {
        string Sign(string text, string key);
    }
}
