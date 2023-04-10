namespace TradingBot.Core.Domain
{
    public enum StopOrderType
    {
        TakeProfit,
        StopLoss,
        TrailingStop,
        Stop,
        PartialTakeProfit,
        PartialStopLoss,
        TakeProfitStopLossOrder
    }
}
