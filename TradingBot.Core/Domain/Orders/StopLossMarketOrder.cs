namespace TradingBot.Core.Domain.Orders
{
    public class StopLossMarketOrder : StopLossOrder, IStopLossMarketOrder
    {
        public StopLossMarketOrder(double volume, double triggerPrice) : base(volume, triggerPrice)
        {

        }
    }
}
