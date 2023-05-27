namespace TradingBot.Core.Converters.Exchange
{
    public interface IExchangeConverter<TQuote, TTicker, TInterval>
    {
        IQuoteConverter<TQuote> Quote { get; }

        ITickerConverter<TTicker> Ticker { get; }

        IIntervalConverter<TInterval> Interval { get; }
    }
}
