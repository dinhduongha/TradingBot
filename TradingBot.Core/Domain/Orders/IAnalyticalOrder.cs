using System.Linq.Expressions;
using TradingBot.Core.Domain.Chart;

namespace TradingBot.Core.Domain.Orders
{
    public interface IAnalyticalOrder<TOrder> : IOpenOrder where TOrder : IMarketOrder, ILimitOrder
    {
        Expression<Func<IEnumerable<ChartDataItem>, TOrder?>> Order { get; }
    }
}
