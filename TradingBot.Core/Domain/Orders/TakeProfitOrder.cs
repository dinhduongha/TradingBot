namespace TradingBot.Core.Domain.Orders
{
    public class TakeProfitOrder : CloseOrder, ITakeProfitOrder
    {
        public double TriggerPrice { get; }

        public TakeProfitOrder(double volume, double triggerPrice) : base(volume)
        {
            if (triggerPrice < 0) throw new ArgumentOutOfRangeException(nameof(triggerPrice));

            TriggerPrice = triggerPrice;
        }
    }
}
