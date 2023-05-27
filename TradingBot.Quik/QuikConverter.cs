using QuikSharp.DataStructures;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Quik.Converters;

namespace TradingBot.Quik
{
    public class QuikConverter : IQuikConverter
    {
        public IQuoteConverter<Candle> Quote => new QuikQuoteConverter();

        public ITickerConverter<SecurityInfo> Ticker => new QuikTickerConverter();

        public IDateTimeConverter<QuikDateTime> DateTime => new QuikDateTimeConverter();

        public IIntervalConverter<CandleInterval> Interval => new QuikIntervalConverter();
    }
}
