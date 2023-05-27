using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.DataProviders
{
    public interface IInstrumentQuotesDataProvider
    {
        IAsyncEnumerable<KeyValuePair<Instrument, IQuote>> Provide();
    }
}
