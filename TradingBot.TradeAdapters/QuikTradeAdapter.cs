using QuikSharp.DataStructures;
using Skender.Stock.Indicators;
using TradingBot.Core.Abstracts;
using TradingBot.Core.Domain;

namespace TradingBot.TradeAdapters
{
    public class QuikTradeAdapter : ITradeAdapter, IFactory<SecurityInfo, StockTicker>
    {
        private readonly QuikSharp.Quik _quik;

        public QuikTradeAdapter(QuikSharp.Quik quik)
        {
            _quik = quik;
        }

        public StockTicker Create(SecurityInfo input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new StockTicker(input.ClassCode, input.Name, input.ShortName, StockExchange.Moex,
                InstrumentType.Stock, new Currency(input.FaceUnit), new LotFilter(input.LotSize),
                            new PriceFilter(Convert.ToDecimal(input.MinPriceStep)));
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var ticker = await _quik.Class.GetSecurityInfo("TQBR", code);

            return ticker != null ? Create(ticker) : throw new NotSupportedException(code);
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
