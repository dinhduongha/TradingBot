using TradingBot.Core.Domain.Chart;

namespace TradingBot.TechnicalAnalyze.Strategies
{
    public class Lev4andTradingStrategy : ITradingStrategy
    {
        public string Name => "Lev4and Strategy";

        public ITradeIdea? SuggestIdea(IEnumerable<ChartDataItem> chartDataItems)
        {
            if (chartDataItems == null || chartDataItems.Count() == 0) return null;

            return null;
        }
    }
}
