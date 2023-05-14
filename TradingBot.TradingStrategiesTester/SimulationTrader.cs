using TradingBot.Core.Domain;
using TradingBot.TechnicalAnalyze;

namespace TradingBot.TradingStrategiesTester
{
    public class SimulationTrader : Trader, ISimulationTrader
    {
        public ITradingStrategy TradingStrategy { get; }

        public SimulationTrader(IWallets wallets, ITradingStrategy tradingStrategy) : base(wallets)
        {
            TradingStrategy = tradingStrategy;
        }
    }
}
