using TradingBot.Core.Domain.Chart;

namespace TradingBot.TechnicalAnalyze
{
    public interface ITradingStrategy
    {
        string Name { get; }

        ITradingIdea? SuggestIdea(IEnumerable<ChartDataItem> chartDataItems);
    }
}
