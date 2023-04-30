namespace TradingBot.Core.Domain.Orders
{
    public interface IStopLossOrder : ICloseOrder
    {
        double TriggerPrice { get; }
    }
}
