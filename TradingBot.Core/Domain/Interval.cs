using System.Runtime.Serialization;

namespace TradingBot.Core.Domain
{
    public enum Interval
    {
        [EnumMember(Value = "M1")]
        OneMinute = 60,
        [EnumMember(Value = "M3")]
        ThreeMinutes = 60 * 3,
        [EnumMember(Value = "M5")]
        FiveMinutes = 60 * 5,
        [EnumMember(Value = "M15")]
        FifteenMinutes = 60 * 15,
        [EnumMember(Value = "M30")]
        ThirtyMinutes = 60 * 30,
        [EnumMember(Value = "H1")]
        OneHour = 60 * 60,
        [EnumMember(Value = "H2")]
        TwoHours = 60 * 60 * 2,
        [EnumMember(Value = "H4")]
        FourHours = 60 * 60 * 4,
        [EnumMember(Value = "D1")]
        OneDay = 60 * 60 * 24,
        [EnumMember(Value = "W1")]
        OneWeek = 60 * 60 * 24 * 7,
        [EnumMember(Value = "MN1")]
        OneMonth = 60 * 60 * 24 * 30
    }
}
