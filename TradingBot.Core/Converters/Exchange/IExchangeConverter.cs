namespace TradingBot.Core.Converters.Exchange
{
    public interface IExchangeConverter<TQuote, TInstrument, TInterval>
    {
        ITickerConverter Ticker { get; }

        IQuoteConverter<TQuote> Quote { get; }

        IIntervalConverter<TInterval> Interval { get; }

        IInstrumentConverter<TInstrument> Instrument { get; }
    }
}
