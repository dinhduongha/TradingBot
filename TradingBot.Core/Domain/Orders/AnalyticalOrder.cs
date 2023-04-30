using System.Linq.Expressions;
using TradingBot.Core.Domain.Chart;

namespace TradingBot.Core.Domain.Orders
{
    public class AnalyticalOrder<TOrder> : OpenOrder, IAnalyticalOrder<TOrder> where TOrder : IMarketOrder, ILimitOrder
    {
        public Expression<Func<IEnumerable<ChartDataItem>, TOrder?>> Order { get; }

        public AnalyticalOrder(double volume, Expression<Func<IEnumerable<ChartDataItem>, TOrder?>> order) :
            base(volume)
        {
            Order = order;
        }
    }
}
