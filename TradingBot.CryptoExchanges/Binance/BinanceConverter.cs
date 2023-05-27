using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Binance.Net.Objects.Models.Spot;
using TradingBot.Core.Converters.Exchange;
using TradingBot.CryptoExchanges.Binance.Converters;

namespace TradingBot.CryptoExchanges.Binance
{
    public partial class BinanceConverter : IBinanceConverter
    {
        public ITickerConverter Ticker => new BinanceTickerConverter();

        public IQuoteConverter<IBinanceKline> Quote => new BinanceQuoteConverter();

        public IIntervalConverter<KlineInterval> Interval => new BinanceIntervalConverter();

        public IInstrumentConverter<BinanceSymbol> Instrument => new BinanceInstrumentConverter();
    }
}
