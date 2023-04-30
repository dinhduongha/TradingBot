namespace TradingBot.Core.Domain.Orders
{
    public class TakeProfitLimitOrder : TakeProfitOrder, ITakeProfitLimitOrder
    {
        public double Price { get; }

        public TakeProfitLimitOrder(double volume, double triggerPrice, double price) : base(volume, triggerPrice)
        {
            if (price <= 0) throw new ArgumentOutOfRangeException(nameof(price));

            Price = price;
        }
    }
}
