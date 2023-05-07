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

        public Task<IEnumerable<IQuote>> GetQuotes(string code, Interval interval, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
