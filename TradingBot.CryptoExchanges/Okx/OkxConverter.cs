using Okex.Net.Enums;
using Okex.Net.Objects.Market;
using Okex.Net.Objects.Public;
using TradingBot.Core.Converters.Exchange;
using TradingBot.CryptoExchanges.Okx.Converters;

namespace TradingBot.CryptoExchanges.Okx
{
    public class OkxConverter : IOkxConverter
    {
        public ITickerConverter Ticker => new OkxTickerConverter();

        public IQuoteConverter<OkexCandlestick> Quote => new OkxQuoteConverter();

        public IIntervalConverter<OkexPeriod> Interval => new OkxIntervalConverter();

        public IInstrumentConverter<OkexInstrument> Instrument => new OkxInstrumentConverter();
    }
}
