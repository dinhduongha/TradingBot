using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.QuotesDataProvider
{
    internal class QuotesDataProviderEventBus
    {
        public event Action<StockTicker, IEnumerable<IQuote>> OnDownloadedQuotes;

        public void RaiseOnDownloadedQuotes(StockTicker ticker, IEnumerable<IQuote> qoutes)
        {
            OnDownloadedQuotes?.Invoke(ticker, qoutes);
        }

        public void Subscribe(Action<StockTicker, IEnumerable<IQuote>> handler)
        {
            OnDownloadedQuotes += handler;
        }

        public void Unsubscribe(Action<StockTicker, IEnumerable<IQuote>> handler)
        {
            OnDownloadedQuotes -= handler;
        }
    }
}
