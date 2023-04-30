using TradingBot.Core.Domain.Chart;

namespace TradingBot.TechnicalAnalyze
{
    public interface ITradingStrategy
    {
        string Name { get; }

        ITradeIdea? SuggestIdea(IEnumerable<ChartDataItem> chartDataItems);
    }
}
