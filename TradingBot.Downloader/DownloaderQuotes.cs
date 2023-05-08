using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.TradeAdapters;

namespace TradingBot.Downloader
{
    public class DownloaderQuotes : IDisposable
    {
        private readonly ITradeAdapter _adapter;

        private readonly DownloaderQuotesActor _actor;
        private readonly DownloaderQuotesEventBus _eventBus;

        private Dictionary<StockTicker, IEnumerable<IQuote>> _stockTickersQuotes;

        public DownloaderQuotes(DateTime from, DateTime to, Interval interval, ITradeAdapter adapter)
        {
            _adapter = adapter;

            _eventBus = new DownloaderQuotesEventBus();
            _eventBus.Subscribe(OnDownloadedQuotes);

            _stockTickersQuotes = new Dictionary<StockTicker, IEnumerable<IQuote>>();
            _actor = new DownloaderQuotesActor(from, to, interval, _adapter, _eventBus);
        }

        public async Task<Dictionary<StockTicker, IEnumerable<IQuote>>> DownloadAsync()
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

        private void OnDownloadedQuotes(StockTicker ticker, IEnumerable<IQuote> quotes)
        {
            _stockTickersQuotes.Add(ticker, quotes);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe(OnDownloadedQuotes);
        }
    }
}
