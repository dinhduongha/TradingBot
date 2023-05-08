using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.Quik.Extensions;

namespace TradingBot.TradeAdapters
{
    public class QuikTradeAdapter : ITradeAdapter
    {
        private readonly QuikSharp.Quik _quik;

        public QuikTradeAdapter(QuikSharp.Quik quik)
        {
            _quik = quik;
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var ticker = await _quik.Class.GetSecurityInfo("TQBR", code);

            return ticker != null ? ticker.ToStockTicker() : throw new NotSupportedException(code);
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

            var candles = await _quik.Candles.GetAllCandles("TQBR", code, interval.MapInterval());

            return candles
                .Where(candle => candle.Datetime.ToDateTime() >= from && candle.Datetime.ToDateTime() <= to)
                .Select(candle => candle.ToQuote());
        }
    }
}
