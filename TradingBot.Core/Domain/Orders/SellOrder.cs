namespace TradingBot.Core.Domain.Orders
{
    public class SellOrder : Order, ISellOrder
    {
        public IOpenOrder Order { get; }

        public IStopLossOrder? StopLossBuy { get; }

        public ITakeProfitOrder? TakeProfitBuy { get; }

        public SellOrder(double volume, IOpenOrder order, IStopLossOrder? stopLossBuy, ITakeProfitOrder? takeProfitBuy) :
            base(volume)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            Order = order;
            StopLossBuy = stopLossBuy;
            TakeProfitBuy = takeProfitBuy;
        }
    }
}
