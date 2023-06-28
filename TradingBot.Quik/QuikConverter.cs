using QuikSharp.DataStructures;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Quik.Converters;

namespace TradingBot.Quik
{
    public class QuikConverter : IQuikConverter
    {
        public ITickerConverter Ticker => new TickerConverter();

        public IQuoteConverter<Candle> Quote => new QuoteConverter();

        public IDateTimeConverter<QuikDateTime> DateTime => new DateTimeConverter();

        public IIntervalConverter<CandleInterval> Interval => new IntervalConverter();

        public IInstrumentConverter<SecurityInfo> Instrument => new InstrumentConverter();

        public IOrderBookConverter<OrderBook> OrderBook => new OrderBookConverter();
    }
}
