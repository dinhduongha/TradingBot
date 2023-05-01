using Okex.Net;

namespace TradingBot.TradeAdapters
{
    public class OkxTradeAdapter : ITradeAdapter
    {
        private readonly OkexClient _client;

        public OkxTradeAdapter(OkexClient client)
        {
            _client = client;
        }
    }
}
