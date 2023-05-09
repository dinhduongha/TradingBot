using TradingBot.Core.Abstracts;
using TradingBot.Core.Domain;

namespace TradingBot.DataProviders
{
    public interface ITickersDataProvider : IProvider<Dictionary<string, StockTicker>>
    {

    }
}
