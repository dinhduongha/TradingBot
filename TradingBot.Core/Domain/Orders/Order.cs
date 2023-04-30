namespace TradingBot.Core.Domain.Orders
{
    public class Order : IOrder
    {
        public double Volume { get; }

        public Order(double volume)
        {
            if (volume <= 0) throw new ArgumentOutOfRangeException(nameof(volume));

            Volume = volume;
        }
    }
}
