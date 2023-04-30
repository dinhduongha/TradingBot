namespace TradingBot.Core.Domain.Orders
{
    public interface ILimitOrder : IOpenOrder
    {
        double Price { get; }
    }
}
