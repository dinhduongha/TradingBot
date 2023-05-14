using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.Core.Domain.Chart;
using TradingBot.DataProviders;

namespace TradingBot.TradingStrategiesTester
{
    public interface ITradingStrategiesTester
    {
        bool IsRunning { get; }

        IEnumerable<ISimulationTrader> Traders { get; }

        IDictionary<StockTicker, IChart> TickersQuotes { get; }

        ITickerQuotesDataProvider TickerQuotesDataProvider { get; }

        void Start();

        void Stop();

        Task TestAsync();
    }
}
