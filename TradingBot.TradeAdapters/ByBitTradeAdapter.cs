using Bybit.Net.Clients;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.HttpClients.ByBit.Extensions;

namespace TradingBot.TradeAdapters
{
    public class ByBitTradeAdapter : ITradeAdapter
    {
        private readonly BybitClient _client;

        public ByBitTradeAdapter(BybitClient client)
        {
            _client = client;
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var response = await _client.V5Api.ExchangeData.GetSpotSymbolsAsync(code);
            var ticker = response?.Data?.List?.SingleOrDefault();

            return ticker != null ? ticker.ToStockTicker() : throw new NotSupportedException(code);
        }

        public async Task<IEnumerable<StockTicker>> GetTickers()
        {
            var response = await _client.V5Api.ExchangeData.GetSpotSymbolsAsync();

            return response?.Data?.List?.Select(symbol => symbol.ToStockTicker()) ?? Enumerable.Empty<StockTicker>();
        }

        public Task<IEnumerable<IQuote>> GetQuotes(string code, Interval interval, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
