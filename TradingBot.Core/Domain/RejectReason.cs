namespace TradingBot.Core.Domain
{
    public enum RejectReason
    {
        NoError,
        Others,
        UnknownMessageType,
        MissingClOrdID,
        MissingOrigClOrdID,
        ClOrdIDOrigClOrdIDAreTheSame,
        DuplicatedClOrdID,
        OrigClOrdIDDoesNotExist,
        TooLateToCancel,
        UnknownOrderType,
        UnknownSide,
        UnknownTimeInForce,
        WronglyRouted,
        MarketOrderPriceIsNotZero,
        LimitOrderInvalidPrice,
        NoEnoughQtyToFill,
        NoImmediateQtyToFill,
        PerCancelRequest,
        MarketOrderCannotBePostOnly,
        PostOnlyWillTakeLiquidity,
        CancelReplaceOrder,
        InvalidSymbolStatus,
    }
}
