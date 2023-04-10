namespace TradingBot.Core.Domain
{
    public enum CancelType
    {
        CancelByUser,
        CancelByReduceOnly,
        CancelByPrepareLiq,
        CancelAllBeforeLiq,
        CancelByPrepareAdl,
        CancelAllBeforeAdl,
        CancelByAdmin,
        CancelByTpSlTsClear,
        CancelByPzSideCh,
    }
}
