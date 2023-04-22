using Skender.Stock.Indicators;

namespace TradingBot.TechnicalAnalyze
{
    public class ChartDataItem
    {
        public DateTime Date { get; }

        public IQuote Quote { get; }

        public IDictionary<string, double?> Indicators { get; }

        public ChartDataItem(DateTime date, IQuote quote, IDictionary<string, double?> indicators)
        {
            if (quote == null) throw new ArgumentNullException(nameof(quote));
            if (indicators == null) throw new ArgumentNullException(nameof(indicators));

            Date = date;
            Quote = quote;
            Indicators = indicators;
        }
    }
}
