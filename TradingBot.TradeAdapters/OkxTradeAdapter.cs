using Okex.Net;
using Okex.Net.Enums;
using Okex.Net.Helpers;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.HttpClients.Okx.Extensions;

namespace TradingBot.TradeAdapters
{
    public class OkxTradeAdapter : ITradeAdapter
    {
        private readonly OkexClient _client;

        public OkxTradeAdapter(OkexClient client)
        {
            _client = client;
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var response = await _client.GetInstrumentsAsync(OkexInstrumentType.Spot, instrumentId: code);
            var ticker = response?.Data?.SingleOrDefault();

            return ticker != null ? ticker.ToStockTicker() : throw new NotSupportedException(code);
        }

        public async Task<IEnumerable<StockTicker>> GetTickers()
        {
            var response = await _client.GetInstrumentsAsync(OkexInstrumentType.Spot);

            return response?.Data?.Select(instrument => instrument.ToStockTicker()) ?? Enumerable.Empty<StockTicker>();
        }

        public async Task<IEnumerable<IQuote>> GetHistoricalQuotes(string code, Interval interval, 
            DateTime from, DateTime to)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));
            if (from > to) throw new ArgumentOutOfRangeException(nameof(from));
            if (to < from) throw new ArgumentOutOfRangeException(nameof(to));

            var response = await _client.GetCandlesticksHistoryAsync(code, interval.MapInterval(), 
                to.ToUnixTimeMilliSeconds(), from.ToUnixTimeMilliSeconds());
            var klines = response?.Data;

            return response?.Data?.Select(kline => kline.ToQuote()) ?? Enumerable.Empty<Quote>();
        }
    }
}
