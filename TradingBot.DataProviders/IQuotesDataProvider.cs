using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.DataProviders
{
    public interface IQuotesDataProvider
    {
        IAsyncEnumerable<IQuote> Provide(Symbol symbol);
    }
}
