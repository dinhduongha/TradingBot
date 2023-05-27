using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Binance.Net.Objects.Models.Spot;
using TradingBot.Core.Converters.Exchange;

namespace TradingBot.CryptoExchanges.Binance
{
    public interface IBinanceConverter : IExchangeConverter<IBinanceKline, BinanceSymbol, KlineInterval>
    {

    }
}
