using Skender.Stock.Indicators;
using TradingBot.Core.Domain.Chart.Indicators;

namespace TradingBot.Core.Domain.Chart
{
    public class Chart : IChart
    {
        public int MaxCountQuotes => 1000;

        public IDictionary<DateTime, IQuote> Quotes { get; }

        public IEnumerable<IIndicator> Indicators { get; }

        public ChartDataItem this[int index] => index < 0 || index >= Quotes.Count ?
            throw new ArgumentOutOfRangeException(nameof(index)) : new ChartDataItem(Quotes.ElementAt(index).Key, 
                Quotes.ElementAt(index).Value, Indicators.ToDictionary(indicator => indicator.Name, indicator => 
                    indicator[index]));

        public ChartDataItem this[DateTime date] => Quotes.ContainsKey(date) ? 
            new ChartDataItem(date, Quotes[date], Indicators.ToDictionary(indicator => 
                indicator.Name, indicator => indicator[date])) : throw new IndexOutOfRangeException(nameof(date));

        public IEnumerable<ChartDataItem> ChartDataItems => Quotes.Select(quote => new ChartDataItem(quote.Key, 
            quote.Value, Indicators.ToDictionary(indicator => indicator.Name, indicator => indicator[quote.Key])));

        public Chart(IEnumerable<IQuote> quotes)
        {
            if (quotes == null) throw new ArgumentNullException(nameof(quotes));

            Quotes = quotes.ToDictionary(quote => quote.Date, quote => quote);

            Indicators = new List<IIndicator>()
            {
                new Bop(quotes),
                new Rsi(quotes, 14),
                new Atr(quotes, 14),
                new Ema(quotes, 5),
                new Ema(quotes, 10),
                new Ema(quotes, 20),
                new Ema(quotes, 50),
                new Ema(quotes, 100),
                new Ema(quotes, 200),
                new ElderRay(quotes, 13),
                new AverageLiquidity(quotes, 5),
                new AverageVolatility(quotes, 5),
            };
        }

        public void Add(IQuote quote)
        {
            ClearQuotes();
            AddOrUpdateQuote(quote);
            UpdateIndicators();
        }

        private void ClearQuotes()
        {
            if (Quotes.Count == MaxCountQuotes) Quotes.Remove(Quotes.ElementAt(0));
        }

        private void AddOrUpdateQuote(IQuote quote)
        {
            if (Quotes.ContainsKey(quote.Date)) Quotes[quote.Date] = quote;
            else Quotes.Add(quote.Date, quote);
        }

        private void UpdateIndicators()
        {
            foreach (var indicator in Indicators)
            {
                indicator.Recalculate(Quotes.Values);
            }
        }
    }
}
