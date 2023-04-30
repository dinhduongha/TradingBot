using TradingBot.Core.Domain.Orders;

namespace TradingBot.TechnicalAnalyze
{
    public interface ITradeIdea
    {
        IBuyOrder? BuyOrder { get; }

        ISellOrder? SellOrder { get; }
    }
}
