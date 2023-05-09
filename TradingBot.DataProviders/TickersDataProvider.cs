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

        public async Task<Dictionary<string, StockTicker>> ProvideAsync()
        {
            var tickers = await _adapter.GetTickers();

            return tickers.ToDictionary(ticker => ticker.Code, ticker => ticker);
        }
    }
}
