using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Binance.Net.Objects.Models.Spot;
using TradingBot.Core.Converters.Exchange;
using TradingBot.CryptoExchanges.Binance.Converters;

namespace TradingBot.CryptoExchanges.Binance
{
    public partial class BinanceConverter : IBinanceConverter
    {
        public IQuoteConverter<IBinanceKline> Quote => new BinanceQuoteConverter();

        public ITickerConverter<BinanceSymbol> Ticker => new BinanceTickerConverter();

        public IIntervalConverter<KlineInterval> Interval => new BinanceIntervalConverter();
    }
}
