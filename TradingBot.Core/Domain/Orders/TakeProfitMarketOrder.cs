namespace TradingBot.Core.Domain.Orders
{
    public class TakeProfitMarketOrder : TakeProfitOrder, ITakeProfitMarketOrder
    {
        public TakeProfitMarketOrder(double volume, double triggerPrice) : base(volume, triggerPrice)
        {

        }
    }
}
