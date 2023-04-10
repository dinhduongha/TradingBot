namespace TradingBot.Core.Domain
{
    public enum WithdrawStatus
    {
        SecurityCheck,
        Pending,
        Success,
        CancelByUser,
        Reject,
        Fail,
        BlockchainConfirmed
    }
}
