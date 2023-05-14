using Skender.Stock.Indicators;
using TradingBot.Core.Domain.Chart;

namespace TradingBot.Core.Extensions
{
    public static class ChartDataItemExtensions
    {
        public static ChartDataItem GetCurrentItem(this IEnumerable<ChartDataItem> chartDataItems)
        {
            return chartDataItems.Last();
        }

        public static ChartDataItem GetPreviousItem(this IEnumerable<ChartDataItem> chartDataItems)
        {
            return chartDataItems.SkipLast(1).Last();
        }
    }
}
