using Skender.Stock.Indicators;

namespace TradingBot.Core.Domain.Chart
{
    public class ChartDataItem
    {
        public DateTime Date { get; }

        public IQuote Quote { get; }

        public IDictionary<string, decimal?> Indicators { get; }

        public ChartDataItem(DateTime date, IQuote quote, IDictionary<string, decimal?> indicators)
        {
            if (quote == null) throw new ArgumentNullException(nameof(quote));
            if (indicators == null) throw new ArgumentNullException(nameof(indicators));

            Date = date;
            Quote = quote;
            Indicators = indicators;
        }
    }
}
