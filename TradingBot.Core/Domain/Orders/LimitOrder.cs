namespace TradingBot.Core.Domain.Orders
{
    public class LimitOrder : Order, ILimitOrder
    {
        public double Price { get; }

        public LimitOrder(double volume, double price) : base(volume)
        {
            if (price <= 0) throw new ArgumentOutOfRangeException(nameof(price));

            Price = price;
        }
    }
}
