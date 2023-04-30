namespace TradingBot.Core.Domain.Orders
{
    public class BuyOrder : Order, IBuyOrder
    {
        public IOpenOrder Order { get; }

        public IStopLossOrder? StopLossSell { get; }

        public ITakeProfitOrder? TakeProfitSell { get; }

        public BuyOrder(double volume, IOpenOrder order, IStopLossOrder? stopLossSell, ITakeProfitOrder? takeProfitSell) : 
            base(volume)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            Order = order;
            StopLossSell = stopLossSell;
            TakeProfitSell = takeProfitSell;
        }
    }
}
