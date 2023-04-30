namespace TradingBot.Core.Domain.Orders
{
    public interface IStopOrder : IOpenOrder, ILimitOrder
    {         
        double TriggerPrice { get; }
    }
}
