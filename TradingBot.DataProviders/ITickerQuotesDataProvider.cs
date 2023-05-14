using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.DataProviders
{
    public interface ITickerQuotesDataProvider
    {
        IAsyncEnumerable<KeyValuePair<StockTicker, IQuote>> Provide();
    }
}
