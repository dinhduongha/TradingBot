namespace TradingBot.Core.Domain.Orders
{
    public class StopOrder : LimitOrder, IStopOrder
    {
        public double TriggerPrice { get; }

        public StopOrder(double volume, double triggerPrice, double price) : base(volume, price)
        {
            if (triggerPrice < 0) throw new ArgumentOutOfRangeException(nameof(triggerPrice));

            TriggerPrice = triggerPrice;
        }
    }
}
