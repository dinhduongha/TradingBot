using Okex.Net;
using Okex.Net.Enums;
using Okex.Net.Helpers;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.CryptoExchanges.Okx;

namespace TradingBot.TradeAdapters
{
    public class OkxTradeAdapter : ITradeAdapter
    {
        private readonly OkexClient _client;
        private readonly OkxConverter _converter;

        public OkxTradeAdapter(OkexClient client, OkxConverter converter)
        {
            _client = client;
            _converter = converter;
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var response = await _client.GetInstrumentsAsync(OkexInstrumentType.Spot, instrumentId: code);

            var ticker = response?.Data?.SingleOrDefault();

            return ticker != null ? _converter.ToTicker(ticker) : throw new NotSupportedException(code);
        }

        public async Task<IEnumerable<StockTicker>> GetTickers()
        {
            var response = await _client.GetInstrumentsAsync(OkexInstrumentType.Spot);

            return response?.Data?.Select(_converter.ToTicker) ?? Enumerable.Empty<StockTicker>();
        }

        public async Task<IEnumerable<IQuote>> GetHistoricalQuotes(string code, Interval interval, 
            DateTime from, DateTime to)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));
            if (from > to) throw new ArgumentOutOfRangeException(nameof(from));
            if (to < from) throw new ArgumentOutOfRangeException(nameof(to));

            var response = await _client.GetCandlesticksHistoryAsync(code, _converter.ToInterval(interval), 
                to.ToUnixTimeMilliSeconds(), from.ToUnixTimeMilliSeconds());

            return response?.Data?.Select(_converter.ToQuote) ?? Enumerable.Empty<Quote>();
        }
    }
}
