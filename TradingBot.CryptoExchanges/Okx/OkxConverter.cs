using Okex.Net.Enums;
using Okex.Net.Objects.Market;
using Okex.Net.Objects.Public;
using TradingBot.Core.Converters.Exchange;
using TradingBot.CryptoExchanges.Okx.Converters;

namespace TradingBot.CryptoExchanges.Okx
{
    public class OkxConverter : IOkxConverter
    {
        public IQuoteConverter<OkexCandlestick> Quote => new OkxQuoteConverter();

        public ITickerConverter<OkexInstrument> Ticker => new OkxTickerConverter();

        public IIntervalConverter<OkexPeriod> Interval => new OkxIntervalConverter();
    }
}
