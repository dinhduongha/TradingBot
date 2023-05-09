using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.TradeAdapters;

namespace TradingBot.DataProviders
{
    public class QuotesDataProvider : IQuotesDataProvider, IDisposable
    {
        private readonly ITradeAdapter _adapter;
        private readonly QuotesDataProviderEventBus _eventBus;

        private DateTime _to;
        private DateTime _from;
        private Interval _interval;
        private QuotesDataProviderActor? _actor;
        private Dictionary<string, IEnumerable<IQuote>> _quotes = new Dictionary<string, IEnumerable<IQuote>>();

        public QuotesDataProvider(DateTime from, DateTime to, Interval interval, ITradeAdapter adapter)
        {
            _adapter = adapter;
            _eventBus = new QuotesDataProviderEventBus();
            _eventBus.Subscribe(OnDownloadedQuotes);

            _to = to;
            _from = from;
            _interval = interval;
        }

        public async IAsyncEnumerable<Dictionary<string, IEnumerable<IQuote>>> ProvideTickersQuotesLazyAsync()
        {
            var limit = 499;
            var tickers = await _adapter.GetTickers();

            var increaseAction = new Func<DateTime, DateTime>((time) => (_to - time).TotalSeconds >= limit
                ? time.AddSeconds((int)_interval * limit)
                : _to);

            for (var time = _from; time <= _to; time = increaseAction.Invoke(time))
            {
                _actor = new QuotesDataProviderActor(time, increaseAction.Invoke(time), _interval, _adapter, _eventBus);

                _quotes.Clear();

                foreach (var ticker in tickers)
                {
                    await _actor.SendAsync(ticker.Code);
                }

                while (_quotes.Count < tickers.Count())
                {
                    await Task.Delay(100);
                }

                yield return _quotes;
            }
        }

        public async IAsyncEnumerable<Dictionary<string, IQuote>> ProvideLazyAsync()
        {
            await foreach (var tickersQuotes in ProvideTickersQuotesLazyAsync())
            {
                var min = tickersQuotes.Min(ticker => ticker.Value.Min(quote => quote.Date));
                var max = tickersQuotes.Max(ticker => ticker.Value.Max(quote => quote.Date));

                for (var time = min; time <= max; time = time.AddSeconds((int)_interval))
                {
                    yield return tickersQuotes.Where(ticker => ticker.Value.Any(quote => quote.Date == time))
                        .ToDictionary(ticker => ticker.Key, ticker => ticker.Value.Single(quote => quote.Date == time));
                }
            }
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe(OnDownloadedQuotes);
        }

        private void OnDownloadedQuotes(string ticker, IEnumerable<IQuote> quotes)
        {
            _quotes.Add(ticker, quotes);
        }
    }
}
