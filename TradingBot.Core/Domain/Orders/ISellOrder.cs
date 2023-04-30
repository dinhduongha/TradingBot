namespace TradingBot.Core.Domain.Orders
{
    public interface ISellOrder : IOrder
    {
        IOpenOrder Order { get; }

        IStopLossOrder? StopLossBuy { get; }

        ITakeProfitOrder? TakeProfitBuy { get; }
    }
}
