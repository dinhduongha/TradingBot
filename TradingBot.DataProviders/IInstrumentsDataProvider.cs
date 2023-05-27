using TradingBot.Core.Abstracts;
using TradingBot.Core.Domain;

namespace TradingBot.DataProviders
{
    public interface IInstrumentsDataProvider : IAsyncLazyProvider<Instrument>
    {

    }
}
