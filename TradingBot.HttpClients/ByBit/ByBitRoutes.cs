namespace TradingBot.HttpClients.ByBit
{
    internal class ByBitRoutes
    {
        public const string Protocol = "https";

        public const string Domain = "api.bybit.com";

        public const string MarketPath = "market";

        public const string MarketGetKlineQuery = "kline?category={Category}&symbol={Symbol}&" +
            "&interval={Interval}&start={Start}&end={End}&limit={Limit}";

        public const string MarketGetInstrumentsInformationQuery = "instruments-info?category={Category}&" +
            "limit={Limit}&cursor={Cursor}";

        public const string MarketGetOrderbookQuery = "orderbook?category={Category}&symbol={Symbol}&" +
            "limit={Limit}";

        public const string MarketGetTickersQuery = "tickers?category={Category}";

        public const string AccountPath = "account";

        public const string AccountGetWalletBalanceQuery = "wallet-balance?accountType={AccountType}";
    }
}
