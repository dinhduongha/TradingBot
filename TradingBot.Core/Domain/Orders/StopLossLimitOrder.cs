namespace TradingBot.Core.Domain.Orders
{
    public class StopLossLimitOrder : StopLossOrder, IStopLossLimitOrder
    {
        public double Price { get; }

        public StopLossLimitOrder(double volume, double triggerPrice, double price) : base(volume, triggerPrice)
        {
            if (price <= 0) throw new ArgumentOutOfRangeException(nameof(price));

            Price = price;
        }
    }
}
