using TradingBot.Core.Domain;

namespace TradingBot.TechnicalAnalyze
{
    public class TradingIdea : ITradingIdea
    {
        public StockTicker Ticker { get; }

        public TradingIdea(StockTicker ticker)
        {
            Ticker = ticker;
        }
    }
}
