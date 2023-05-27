using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using TradingBot.Core.Converters.Exchange;

namespace TradingBot.CryptoExchanges.ByBit
{
    public interface IByBitConverter : IExchangeConverter<BybitKline, BybitSpotSymbol, KlineInterval>
    {

    }
}
