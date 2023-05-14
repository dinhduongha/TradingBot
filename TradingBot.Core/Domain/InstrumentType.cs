using System.Runtime.Serialization;

namespace TradingBot.Core.Domain
{
    public enum InstrumentType
    {
        [EnumMember(Value = "Spot")]
        Spot,
        [EnumMember(Value = "Stock")]
        Stock
    }
}
