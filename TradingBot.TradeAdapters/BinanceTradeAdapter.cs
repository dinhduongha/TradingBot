using Binance.Net.Clients;

namespace TradingBot.TradeAdapters
{
    public class BinanceTradeAdapter : ITradeAdapter
    {
        private readonly BinanceClient _client;

        public BinanceTradeAdapter(BinanceClient client)
        {
            _client = client;
        }
    }
}
