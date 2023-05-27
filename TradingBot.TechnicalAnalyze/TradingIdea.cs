using TradingBot.Core.Domain;

namespace TradingBot.TechnicalAnalyze
{
    public class TradingIdea : ITradingIdea
    {
        public Instrument Ticker { get; }

        public TradingIdea(Instrument ticker)
        {
            Ticker = ticker;
        }
    }
}
