using Skender.Stock.Indicators;

namespace TradingBot.Core.Domain.Chart
{
    public abstract class Indicator : IIndicator
    {
        public int MaxCountQuotes => 1000;

        public abstract string Name { get; }

        public IDictionary<DateTime, decimal?> Data { get; set; }

        public decimal? this[int index] => index < 0 || index >= Data.Count
            ? throw new ArgumentOutOfRangeException(nameof(index)) : Data.ElementAt(index).Value;

        public decimal? this[DateTime date] => Data.ContainsKey(date)
            ? Data[date] : throw new IndexOutOfRangeException(nameof(date));

        public Indicator()
        {
            Data = new Dictionary<DateTime, decimal?>();
        }

        public void Recalculate(IEnumerable<IQuote> quotes)
        {
            Data = Calculate(quotes)
                .TakeLast(MaxCountQuotes)
                .ToDictionary(data => data.Key, data => data.Value);
        }

        public abstract IDictionary<DateTime, decimal?> Calculate(IEnumerable<IQuote> quotes);
    }
}
