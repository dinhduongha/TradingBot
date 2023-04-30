namespace TradingBot.Core.Domain.Orders
{
    public class MarketOrder : Order, IMarketOrder
    {
        public MarketOrder(double volume) : base(volume)
        {

        }
    }
}
