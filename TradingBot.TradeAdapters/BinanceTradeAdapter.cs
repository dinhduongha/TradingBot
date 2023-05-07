using Binance.Net.Clients;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.HttpClients.Binance.Extensions;

namespace TradingBot.TradeAdapters
{
    public class BinanceTradeAdapter : ITradeAdapter
    {
        private readonly BinanceClient _client;

        public BinanceTradeAdapter(BinanceClient client)
        {
            _client = client;
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var response = await _client.SpotApi.ExchangeData.GetExchangeInfoAsync(code);
            var ticker = response?.Data?.Symbols?.SingleOrDefault();

            return ticker != null ? ticker.ToStockTicker() : throw new NotSupportedException(code);
        }

        public async Task<IEnumerable<StockTicker>> GetTickers()
        {
            var response = await _client.SpotApi.ExchangeData.GetExchangeInfoAsync();

            return response?.Data?.Symbols?.Select(symbol => symbol.ToStockTicker()) ?? Enumerable.Empty<StockTicker>();
        }

        public Task<IEnumerable<IQuote>> GetQuotes(string code, Interval interval, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
