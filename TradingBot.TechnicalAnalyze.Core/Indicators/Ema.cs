using Skender.Stock.Indicators;

namespace TradingBot.TechnicalAnalyze.Core.Indicators
{
    public class Ema : Indicator
    {
        public int Length { get; }

        public override string Name => $"EMA {Length}";

        public Ema(IEnumerable<IQuote> quotes, int length)
        {
            if (length < 1) throw new ArgumentOutOfRangeException(nameof(length));

            Length = length;

            Recalculate(quotes);
        }

        public override IDictionary<DateTime, double?> Calculate(IEnumerable<IQuote> quotes)
        {
            return quotes.GetEma(Length).ToDictionary(data => data.Date, data => data.Ema);
        }
    }
}
