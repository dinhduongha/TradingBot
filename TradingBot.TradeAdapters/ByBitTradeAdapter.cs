using Bybit.Net.Clients;

namespace TradingBot.TradeAdapters
{
    public class ByBitTradeAdapter : ITradeAdapter
    {
        private readonly BybitClient _client;

        public ByBitTradeAdapter(BybitClient client)
        {
            _client = client;
        }
    }
}
