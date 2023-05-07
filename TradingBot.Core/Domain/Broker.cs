using System.Runtime.Serialization;

namespace TradingBot.Core.Domain
{
    public enum Broker
    {
        [EnumMember(Value = "OKX")]
        Okx,
        [EnumMember(Value = "ByBit")]
        ByBit,
        [EnumMember(Value = "Binance")]
        Binance,
        [EnumMember(Value = "VTB Investment")]
        Vtb,
        [EnumMember(Value = "BCS Investment")]
        Bcs,
        [EnumMember(Value = "SBER Investment")]
        Sber,
    }
}
