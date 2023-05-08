using TradingBot.Core.Domain.Orders;

namespace TradingBot.TechnicalAnalyze
{
    public interface ITradingIdea
    {
        IBuyOrder? BuyOrder { get; }

        ISellOrder? SellOrder { get; }
    }
}
