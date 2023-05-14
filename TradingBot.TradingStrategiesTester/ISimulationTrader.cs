using TradingBot.Core.Domain;
using TradingBot.TechnicalAnalyze;

namespace TradingBot.TradingStrategiesTester
{
    public interface ISimulationTrader : ITrader
    {
        ITradingStrategy TradingStrategy { get; }
    }
}
