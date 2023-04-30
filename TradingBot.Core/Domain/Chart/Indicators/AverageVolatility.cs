using Skender.Stock.Indicators;

namespace TradingBot.Core.Domain.Chart.Indicators
{
    public class AverageVolatility : Indicator
    {
        public int Length { get; }

        public override string Name => "Average volatility";

        public AverageVolatility(IEnumerable<IQuote> quotes, int length)
        {
            if (length < 1) throw new ArgumentOutOfRangeException(nameof(length));

            Length = length;

            Recalculate(quotes);
        }

        public override IDictionary<DateTime, double?> Calculate(IEnumerable<IQuote> quotes)
        {
            var result = new Dictionary<DateTime, double?>();
            var sortedQuotes = quotes.OrderBy(quote => quote.Date);

            for (var i = 0; i < quotes.Count(); i++)
            {
                result.Add(sortedQuotes.ElementAt(i).Date, sortedQuotes.Where((quote, index) => index <= i &&
                    i - index <= Length).Select(quote => Math.Abs(Convert.ToDouble(quote.Close - quote.Open))).Average());
            }

            return result;
        }
    }
}
