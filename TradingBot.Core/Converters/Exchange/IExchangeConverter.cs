using TradingBot.Core.Domain;

namespace TradingBot.Core.Converters.Exchange
{
    public interface IExchangeConverter<TQuote, TInstrument, TInterval, TOrderBook>
    {
        ITickerConverter Ticker { get; }

        IQuoteConverter<TQuote> Quote { get; }

        IIntervalConverter<TInterval> Interval { get; }

        IOrderBookConverter<TOrderBook> OrderBook { get; }

        IInstrumentConverter<TInstrument> Instrument { get; }
    }
}
