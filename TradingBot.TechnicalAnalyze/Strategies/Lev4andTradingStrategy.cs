using TradingBot.Core.Domain;
using TradingBot.Core.Domain.Chart;

namespace TradingBot.TechnicalAnalyze.Strategies
{
    public class Lev4andTradingStrategy : ITradingStrategy
    {
        public string Name => "Lev4and Strategy";

        public ITradingIdea? SuggestIdea(StockTicker ticker, IEnumerable<ChartDataItem> chartDataItems)
        {
            return null;
        }
    }
}
