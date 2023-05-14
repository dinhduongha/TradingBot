using Skender.Stock.Indicators;
using TradingBot.Core.Extensions;

namespace TradingBot.Core.Domain.Chart.Indicators
{
    public class Rsi : Indicator
    {
        public int Length { get; }

        public override string Name => $"RSI {Length}";

        public Rsi(IEnumerable<IQuote> quotes, int length)
        {
            if (length < 1) throw new ArgumentOutOfRangeException(nameof(length));

            Length = length;

            Recalculate(quotes);
        }

        public override IDictionary<DateTime, decimal?> Calculate(IEnumerable<IQuote> quotes)
        {
            return quotes.GetRsi(Length).ToDictionary(data => data.Date, data => data.Rsi.ToDecimal());
        }
    }
}
