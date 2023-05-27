using Bitfinex.Net.Enums;
using Bitfinex.Net.Objects.Models;
using Bitfinex.Net.Objects.Models.V1;
using TradingBot.Core.Converters.Exchange;
using TradingBot.CryptoExchanges.Bitfinex.Converters;

namespace TradingBot.CryptoExchanges.Bitfinex
{
    public partial class BitfinexConverter : IBitfinexConverter
    {
        public ITickerConverter Ticker => new BitfinexTickerConverter();

        public IQuoteConverter<BitfinexKline> Quote => new BitfinexQuoteConverter();

        public IIntervalConverter<KlineInterval> Interval => new BitfinexIntervalConverter();

        public IInstrumentConverter<BitfinexSymbolDetails> Instrument => new BitfinexInstrumentConverter();
    }
}
