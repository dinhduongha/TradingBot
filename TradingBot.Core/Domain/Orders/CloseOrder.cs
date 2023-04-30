namespace TradingBot.Core.Domain.Orders
{
    public class CloseOrder : Order, ICloseOrder
    {
        public CloseOrder(double volume) : base(volume)
        {
            
        }
    }
}
