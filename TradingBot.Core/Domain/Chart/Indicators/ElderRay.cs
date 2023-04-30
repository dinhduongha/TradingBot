using Skender.Stock.Indicators;

namespace TradingBot.Core.Domain.Chart.Indicators
{
    public class ElderRay : Indicator
    {
        public int Length { get; }

        public override string Name => $"ElderRay {Length}";

        public ElderRay(IEnumerable<IQuote> quotes, int length)
        {
            if (length < 1) throw new ArgumentOutOfRangeException(nameof(length));

            Length = length;

            Recalculate(quotes);
        }

        public override IDictionary<DateTime, double?> Calculate(IEnumerable<IQuote> quotes)
        {
            return quotes.GetElderRay(Length).ToDictionary(data => data.Date, data => data.Ema);
        }
    }
}
