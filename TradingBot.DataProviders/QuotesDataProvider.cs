using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.TradeAdapters;

namespace TradingBot.DataProviders
{
    public class QuotesDataProvider : IQuotesDataProvider
    {
        private readonly ITradeAdapter _adapter;

        private DateTime _to;
        private DateTime _from;
        private Interval _interval;

        public QuotesDataProvider(DateTime from, DateTime to, Interval interval, ITradeAdapter adapter)
        {
            if (from > to) throw new ArgumentOutOfRangeException(nameof(from));
            if (to < from) throw new ArgumentOutOfRangeException(nameof(to));

            _to = to;
            _from = from;
            _adapter = adapter;
            _interval = interval;
        }

        public async IAsyncEnumerable<IQuote> Provide(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var to = _to;
            var result = new List<IQuote>();

            while (to >= _from)
            {
                var quotes = await _adapter.GetHistoricalQuotes(code, _interval, _from, to);

                if (quotes != null && quotes.Count() > 0)
                {
                    result.AddRange(quotes);

                    to = quotes.Min(quote => quote.Date).AddSeconds(-(int)_interval);
                }
                else break;
            }

            result = result.OrderBy(quote => quote.Date).ToList();

            foreach (var quote in result)
            {
                yield return quote;
            }
        }
    }
}
