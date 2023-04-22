using Skender.Stock.Indicators;

namespace TradingBot.TechnicalAnalyze.Core
{
    public abstract class Indicator : IIndicator
    {
        public int MaxCountQuotes => 1000;

        public abstract string Name { get; }

        public IDictionary<DateTime, double?> Data { get; set; }

        public double? this[int index] => index < 0 || index >= Data.Count 
            ? throw new ArgumentOutOfRangeException(nameof(index)) : Data.ElementAt(index).Value;

        public double? this[DateTime date] => Data.ContainsKey(date)
            ? Data[date] : throw new IndexOutOfRangeException(nameof(date));

        public Indicator()
        {
            Data = new Dictionary<DateTime, double?>();
        }

        public void Recalculate(IEnumerable<IQuote> quotes)
        {
            Data = Calculate(quotes)
                .TakeLast(MaxCountQuotes)
                .ToDictionary(data => data.Key, data => data.Value);
        }

        public abstract IDictionary<DateTime, double?> Calculate(IEnumerable<IQuote> quotes);
    }
}
