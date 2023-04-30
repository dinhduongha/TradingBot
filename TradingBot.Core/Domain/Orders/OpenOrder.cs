namespace TradingBot.Core.Domain.Orders
{
    public class OpenOrder : Order, IOpenOrder
    {
        public OpenOrder(double volume) : base(volume)
        {

        }
    }
}
