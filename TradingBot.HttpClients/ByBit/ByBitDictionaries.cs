using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.ByBit
{
    public static class ByBitDictionaries
    {
        public static Dictionary<Category, string> Categories = 
            new Dictionary<Category, string>
            {
                { Category.Spot, "spot" },
                { Category.Linear, "linear" },
                { Category.Inverse, "inverse" },
                { Category.Option, "option" }
            };

        public static Dictionary<OrderStatus, string> OrderStatues = 
            new Dictionary<OrderStatus, string>
            {
                { OrderStatus.Created, "Created" },
                { OrderStatus.New, "New" },
                { OrderStatus.Rejected, "Rejected" },
                { OrderStatus.PartiallyFilled, "PartiallyFilled" },
                { OrderStatus.PartiallyFilledCanceled, "PartiallyFilledCanceled" },
                { OrderStatus.Filled, "Filled" },
                { OrderStatus.Cancelled, "Cancelled" },
                { OrderStatus.Untriggered, "Untriggered" },
                { OrderStatus.Triggered, "Triggered" },
                { OrderStatus.Deactivated, "Deactivated" },
                { OrderStatus.Active, "Active" },
            };

        public static Dictionary<TimeInForce, string> TimesInForce =
            new Dictionary<TimeInForce, string>
            {
                { TimeInForce.GoodTillCancel, "GTC" },
                { TimeInForce.ImmediateOrCancel, "IOC" },
                { TimeInForce.FillOrKill, "FOK" },
            };

        public static Dictionary<ExecutionType, string> ExecutionTypes =
            new Dictionary<ExecutionType, string>
            {
                { ExecutionType.Trade, "Trade" },
                { ExecutionType.AutoDeleveragingTrade, "AdlTrade" },
                { ExecutionType.Funding, "Funding" },
                { ExecutionType.BustTrade, "BustTrade" },
                { ExecutionType.Settle, "Settle" },
                { ExecutionType.Delivery, "Delivery" },
            };

        public static Dictionary<StopOrderType, string> StopOrderTypes =
            new Dictionary<StopOrderType, string>
            {
                { StopOrderType.TakeProfit, "TakeProfit" },
                { StopOrderType.StopLoss, "StopLoss" },
                { StopOrderType.TrailingStop, "TrailingStop" },
                { StopOrderType.Stop, "Stop" },
                { StopOrderType.PartialTakeProfit, "PartialTakeProfit" },
                { StopOrderType.PartialStopLoss, "PartialStopLoss" },
                { StopOrderType.TakeProfitStopLossOrder, "tpslOrder" }
            };

        public static Dictionary<TickDirection, string> TickDirections =
            new Dictionary<TickDirection, string>
            {
                { TickDirection.PlusTick, "PlusTick" },
                { TickDirection.ZeroPlusTick, "ZeroPlusTick" },
                { TickDirection.MinusTick, "MinusTick" },
                { TickDirection.ZeroMinusTick, "ZeroMinusTick" }
            };

        public static Dictionary<Interval, string> Intervals =
            new Dictionary<Interval, string>
            {
                { Interval.Minute, "1" },
                { Interval.ThreeMinutes, "3" },
                { Interval.FiveMinutes, "5" },
                { Interval.QuarterHour, "15" },
                { Interval.HalfHour, "30" },
                { Interval.Hour, "60" },
                { Interval.TwoHours, "120" },
                { Interval.FourHours, "240" },
                { Interval.QuarterDay, "360" },
                { Interval.HalfDay, "720" },
                { Interval.Day, "D" },
                { Interval.Week, "W" },
                { Interval.Month, "M" }
            };

        public static Dictionary<PositionStatus, string> PositionStatuses =
            new Dictionary<PositionStatus, string>
            {
                { PositionStatus.Normal, "Normal" },
                { PositionStatus.LiquidationProgress, "Liq" },
                { PositionStatus.AutoDeleverageProgress, "Adl" }
            };

        public static Dictionary<RejectReason, string> RejectReasons =
            new Dictionary<RejectReason, string>
            {
                { RejectReason.NoError, "EC_NoError" },
                { RejectReason.Others, "EC_Others" },
                { RejectReason.UnknownMessageType, "EC_UnknownMessageType" },
                { RejectReason.MissingClOrdID, "EC_MissingClOrdID" },
                { RejectReason.MissingOrigClOrdID, "EC_MissingOrigClOrdID" },
                { RejectReason.ClOrdIDOrigClOrdIDAreTheSame, "EC_ClOrdIDOrigClOrdIDAreTheSame" },
                { RejectReason.DuplicatedClOrdID, "EC_DuplicatedClOrdID" },
                { RejectReason.OrigClOrdIDDoesNotExist, "EC_OrigClOrdIDDoesNotExist" },
                { RejectReason.TooLateToCancel, "EC_TooLateToCancel" },
                { RejectReason.UnknownOrderType, "EC_UnknownOrderType" },
                { RejectReason.UnknownSide, "EC_UnknownSide" },
                { RejectReason.UnknownTimeInForce, "EC_UnknownTimeInForce" },
                { RejectReason.WronglyRouted, "EC_WronglyRouted" },
                { RejectReason.MarketOrderPriceIsNotZero, "EC_MarketOrderPriceIsNotZero" },
                { RejectReason.LimitOrderInvalidPrice, "EC_LimitOrderInvalidPrice" },
                { RejectReason.NoEnoughQtyToFill, "EC_NoEnoughQtyToFill" },
                { RejectReason.NoImmediateQtyToFill, "EC_NoImmediateQtyToFill" },
                { RejectReason.PerCancelRequest, "EC_PerCancelRequest" },
                { RejectReason.MarketOrderCannotBePostOnly, "EC_MarketOrderCannotBePostOnly" },
                { RejectReason.PostOnlyWillTakeLiquidity, "EC_PostOnlyWillTakeLiquidity" },
                { RejectReason.CancelReplaceOrder, "EC_CancelReplaceOrder" },
                { RejectReason.InvalidSymbolStatus, "EC_InvalidSymbolStatus" }
            };

        public static Dictionary<AccountType, string> AccountTypes =
            new Dictionary<AccountType, string>
            {
                { AccountType.Contract, "CONTRACT" },
                { AccountType.Spot, "SPOT" },
                { AccountType.Investment, "INVESTMENT" },
                { AccountType.Option, "OPTION" },
                { AccountType.Unified, "UNIFIED" },
                { AccountType.Fund, "FUND" }
            };

        public static Dictionary<TransferStatus, string> TransferStatuses =
            new Dictionary<TransferStatus, string>
            {
                { TransferStatus.Success, "SUCCESS" },
                { TransferStatus.Pending, "PENDING" },
                { TransferStatus.Failed, "FAILED" }
            };

        public static Dictionary<WithdrawStatus, string> WithdrawStatuses =
            new Dictionary<WithdrawStatus, string>
            {
                { WithdrawStatus.SecurityCheck, "SecurityCheck" },
                { WithdrawStatus.Pending, "Pending" },
                { WithdrawStatus.Success, "success" },
                { WithdrawStatus.CancelByUser, "CancelByUser" },
                { WithdrawStatus.Reject, "Reject" },
                { WithdrawStatus.Fail, "Fail" },
                { WithdrawStatus.BlockchainConfirmed, "BlockchainConfirmed" }
            };

        public static Dictionary<TriggerBy, string> Triggers =
            new Dictionary<TriggerBy, string>
            {
                { TriggerBy.LastPrice, "LastPrice" },
                { TriggerBy.IndexPrice, "IndexPrice" },
                { TriggerBy.MarkPrice, "MarkPrice" }
            };

        public static Dictionary<CancelType, string> CancelTypes =
            new Dictionary<CancelType, string>
            {
                { CancelType.CancelByUser, "CancelByUser" },
                { CancelType.CancelByReduceOnly, "CancelByReduceOnly" },
                { CancelType.CancelByPrepareLiq, "CancelByPrepareLiq" },
                { CancelType.CancelAllBeforeLiq, "CancelAllBeforeLiq" },
                { CancelType.CancelByPrepareAdl, "CancelByPrepareAdl" },
                { CancelType.CancelAllBeforeAdl, "CancelAllBeforeAdl" },
                { CancelType.CancelByAdmin, "CancelByAdmin" },
                { CancelType.CancelByTpSlTsClear, "CancelByTpSlTsClear" },
                { CancelType.CancelByPzSideCh, "CancelByPzSideCh" }
            };
    }
}
