namespace TradingBot.Core.Domain.Orders
{
    public class StopLossOrder : CloseOrder, IStopLossOrder
    {
        public double TriggerPrice { get; }

        public StopLossOrder(double volume, double triggerPrice) : base(volume)
        {
            if (triggerPrice < 0) throw new ArgumentOutOfRangeException(nameof(triggerPrice));

            TriggerPrice = triggerPrice;
        }
    }
}
