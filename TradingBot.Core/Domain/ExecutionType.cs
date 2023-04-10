namespace TradingBot.Core.Domain
{
    public enum ExecutionType
    {
        Trade,
        AutoDeleveragingTrade,
        Funding,
        BustTrade,
        Settle,
        Delivery
    }
}
