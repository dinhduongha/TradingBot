using Bitfinex.Net.Objects.Models.V1;
using Bitfinex.Net.Objects.Models;
using TradingBot.Core.Converters.Exchange;
using Bitfinex.Net.Enums;

namespace TradingBot.CryptoExchanges.Bitfinex
{
    public interface IBitfinexConverter : IExchangeConverter<BitfinexKline, BitfinexSymbolDetails, KlineInterval>
    {

    }
}
