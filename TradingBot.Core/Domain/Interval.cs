using System.Runtime.Serialization;

namespace TradingBot.Core.Domain
{
    public enum Interval
    {
        [EnumMember(Value = "M1")]
        OneMinute = 60,
        [EnumMember(Value = "M5")]
        FiveMinutes = 60 * 5,
        [EnumMember(Value = "H1")]
        OneHour = 60 * 60,
        [EnumMember(Value = "D1")]
        OneDay = 60 * 60 * 24
    }
}
