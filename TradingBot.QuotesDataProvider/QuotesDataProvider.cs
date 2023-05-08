using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.TradeAdapters;

namespace TradingBot.QuotesDataProvider
{
    public class QuotesDataProvider : IQuotesDataProvider, IDisposable
    {
        private readonly ITradeAdapter _adapter;

        private readonly QuotesDataProviderActor _actor;
        private readonly QuotesDataProviderEventBus _eventBus;

        private Dictionary<StockTicker, IEnumerable<IQuote>> _stockTickersQuotes;

        public QuotesDataProvider(DateTime from, DateTime to, Interval interval, ITradeAdapter adapter)
        {
            _adapter = adapter;

            _eventBus = new QuotesDataProviderEventBus();
            _eventBus.Subscribe(OnDownloadedQuotes);

            _stockTickersQuotes = new Dictionary<StockTicker, IEnumerable<IQuote>>();
            _actor = new QuotesDataProviderActor(from, to, interval, _adapter, _eventBus);
        }

        public async Task<Dictionary<StockTicker, IEnumerable<IQuote>>> ProvideAsync()
        {
            _stockTickersQuotes.Clear();

            var tickers = await _adapter.GetTickers();

            foreach (var ticker in tickers)
            {
                await _actor.SendAsync(ticker);
            }

            while (_stockTickersQuotes.Count < tickers.Count())
            {
                await Task.Delay(100);
            }

            return _stockTickersQuotes;
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe(OnDownloadedQuotes);
        }

        private void OnDownloadedQuotes(StockTicker ticker, IEnumerable<IQuote> quotes)
        {
            _stockTickersQuotes.Add(ticker, quotes);
        }
    }
}
