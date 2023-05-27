using QuikSharp.DataStructures;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Quik.Converters;

namespace TradingBot.Quik
{
    public class QuikConverter : IQuikConverter
    {
        public ITickerConverter Ticker => new QuikTickerConverter();

        public IQuoteConverter<Candle> Quote => new QuikQuoteConverter();

        public IDateTimeConverter<QuikDateTime> DateTime => new QuikDateTimeConverter();

        public IIntervalConverter<CandleInterval> Interval => new QuikIntervalConverter();

        public IInstrumentConverter<SecurityInfo> Instrument => new QuikInstrumentConverter();
    }
}
