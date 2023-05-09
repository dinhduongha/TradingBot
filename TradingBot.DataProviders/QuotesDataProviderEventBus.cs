using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.DataProviders
{
    internal class QuotesDataProviderEventBus
    {
        public event Action<string, IEnumerable<IQuote>> OnDownloadedQuotes;

        public void RaiseOnDownloadedQuotes(string ticker, IEnumerable<IQuote> qoutes)
        {
            OnDownloadedQuotes?.Invoke(ticker, qoutes);
        }

        public void Subscribe(Action<string, IEnumerable<IQuote>> handler)
        {
            OnDownloadedQuotes += handler;
        }

        public void Unsubscribe(Action<string, IEnumerable<IQuote>> handler)
        {
            OnDownloadedQuotes -= handler;
        }
    }
}
