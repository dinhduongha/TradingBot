using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.Quik;

namespace TradingBot.TradeAdapters
{
    public class QuikTradeAdapter : ITradeAdapter
    {
        private readonly QuikSharp.Quik _quik;
        private readonly QuikConverter _converter;

        public QuikTradeAdapter(QuikSharp.Quik quik, QuikConverter converter)
        {
            _quik = quik;
            _converter = converter;
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var ticker = await _quik.Class.GetSecurityInfo("TQBR", code);

            return ticker != null ? _converter.Ticker.Convert(ticker) : throw new NotSupportedException(code);
        }

        public async Task<IEnumerable<StockTicker>> GetTickers()
        {
            var codes = await _quik.Class.GetClassSecurities("TQBR");

            var tickers = new List<StockTicker>();

            foreach (var code in codes)
            {
                tickers.Add(await GetTicker(code));
            }

            return tickers;
        }

        public async Task<IEnumerable<IQuote>> GetHistoricalQuotes(string code, Interval interval, 
            DateTime from, DateTime to)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));
            if (from > to) throw new ArgumentOutOfRangeException(nameof(from));
            if (to < from) throw new ArgumentOutOfRangeException(nameof(to));

            var candles = await _quik.Candles.GetAllCandles("TQBR", code, _converter.Interval.Convert(interval));

            return candles
                .Where(candle => _converter.DateTime.Convert(candle.Datetime) >= from &&
                    _converter.DateTime.Convert(candle.Datetime) <= to)
                .Select(_converter.Quote.Convert);
        }
    }
}
