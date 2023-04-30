namespace TradingBot.Core.Domain.Orders
{
    public interface IBuyOrder : IOrder
    {
        IOpenOrder Order { get; }

        IStopLossOrder? StopLossSell { get; }

        ITakeProfitOrder? TakeProfitSell { get; }
    }
}
