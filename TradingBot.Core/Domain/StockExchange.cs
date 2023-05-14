using System.Runtime.Serialization;

namespace TradingBot.Core.Domain
{
    public enum StockExchange
    {
        [EnumMember(Value = "OKX")]
        Okx,
        [EnumMember(Value = "ByBit")]
        ByBit,
        [EnumMember(Value = "Binance")]
        Binance,
        [EnumMember(Value = "MOEX")]
        Moex,
        [EnumMember(Value = "SPBEX")]
        Spbex,
        [EnumMember(Value = "NASDAQ")]
        Nasdaq
    }
}
