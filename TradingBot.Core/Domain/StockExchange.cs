using System.Runtime.Serialization;

namespace TradingBot.Core.Domain
{
    public enum StockExchange
    {
        [EnumMember(Value = "OKX")]
        Okx,
        [EnumMember(Value = "BYBIT")]
        ByBit,
        [EnumMember(Value = "BINANCE")]
        Binance,
        [EnumMember(Value = "MOEX")]
        Moex,
        [EnumMember(Value = "SPBEX")]
        Spbex,
        [EnumMember(Value = "NASDAQ")]
        Nasdaq
    }
}
