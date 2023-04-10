namespace TradingBot.HttpClients.ByBit
{
    public class ByBitHttpContext
    {
        public AccountHttpClient Account { get; }

        public MarketHttpClient Market { get; }

        public ByBitHttpContext(AccountHttpClient account, MarketHttpClient market)
        {
            Account = account;
            Market = market;
        }
    }
}
