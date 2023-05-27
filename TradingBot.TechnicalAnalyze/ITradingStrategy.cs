using TradingBot.Core.Domain;
using TradingBot.Core.Domain.Chart;

namespace TradingBot.TechnicalAnalyze
{
    public interface ITradingStrategy
    {
        string Name { get; }

        ITradingIdea? SuggestIdea(Instrument ticker, IEnumerable<ChartDataItem> chartDataItems);
    }
}
