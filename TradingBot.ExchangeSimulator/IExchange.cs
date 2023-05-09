using TradingBot.Core.Domain;
using TradingBot.Core.Domain.Chart;

namespace TradingBot.ExchangeSimulator
{
    public interface IExchange
    {
        DateTime Time { get; }

        Dictionary<string, StockTicker> Tickers { get; }

        Dictionary<string, IChart> Quotes { get; }
    }
}
