using Skender.Stock.Indicators;

namespace TradingBot.TechnicalAnalyze.Core
{
    public class ChartDataItem
    {
        public DateTime StartedAt { get; }

        public IQuote Quote { get; }

        public IDictionary<string, double?> Indicators { get; }

        public ChartDataItem(DateTime startedAt, IQuote quote, IDictionary<string, double?> indicators)
        {
            if (quote == null) throw new ArgumentNullException(nameof(quote));
            if (indicators == null) throw new ArgumentNullException(nameof(indicators));

            StartedAt = startedAt;
            Quote = quote;
            Indicators = indicators;
        }
    }
}
