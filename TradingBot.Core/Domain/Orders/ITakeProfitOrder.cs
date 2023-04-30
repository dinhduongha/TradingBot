namespace TradingBot.Core.Domain.Orders
{
    public interface ITakeProfitOrder : ICloseOrder
    {
        double TriggerPrice { get; }
    }
}
