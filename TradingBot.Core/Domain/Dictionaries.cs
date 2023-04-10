namespace TradingBot.Core.Domain
{
    public static class Dictionaries
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


    }
}
