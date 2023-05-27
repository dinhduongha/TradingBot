using Binance.Net.Clients;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.CryptoExchanges.Binance;

namespace TradingBot.TradeAdapters
{
    public class BinanceTradeAdapter : ITradeAdapter
    {
        private readonly BinanceClient _client;
        private readonly BinanceConverter _converter;

        public BinanceTradeAdapter(BinanceClient client, BinanceConverter converter)
        {
            _client = client;
            _converter = converter;
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var response = await _client.SpotApi.ExchangeData.GetExchangeInfoAsync(code);

            var ticker = response?.Data?.Symbols?.SingleOrDefault();

            return ticker != null ? _converter.Ticker.Convert(ticker) : throw new NotSupportedException(code);
        }

        public async Task<IEnumerable<StockTicker>> GetTickers()
        {
            var response = await _client.SpotApi.ExchangeData.GetExchangeInfoAsync();

            return response?.Data?.Symbols?.Select(_converter.Ticker.Convert) ?? Enumerable.Empty<StockTicker>();
        }

        public async Task<IEnumerable<IQuote>> GetHistoricalQuotes(string code, Interval interval, 
            DateTime from, DateTime to)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));
            if (from > to) throw new ArgumentOutOfRangeException(nameof(from));
            if (to < from) throw new ArgumentOutOfRangeException(nameof(to));

            var response = await _client.SpotApi.ExchangeData
                .GetKlinesAsync(code, _converter.Interval.Convert(interval), from, to);

            var klines = response?.Data;

            return response?.Data?.Select(_converter.Quote.Convert) ?? Enumerable.Empty<Quote>();
        }
    }
}
