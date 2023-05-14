using TradingBot.Core.Domain;
using TradingBot.TradeAdapters;

namespace TradingBot.DataProviders
{
    public class TickersDataProvider : ITickersDataProvider
    {
        private readonly ITradeAdapter _adapter;

        public TickersDataProvider(ITradeAdapter adapter)
        {
            _adapter = adapter;
        }

        public async IAsyncEnumerable<StockTicker> Provide()
        {
            var tickers = await _adapter.GetTickers();

            foreach (var ticker in tickers)
            {
                yield return ticker;
            }
        }
    }
}
