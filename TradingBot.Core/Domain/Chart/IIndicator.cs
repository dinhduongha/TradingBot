using Skender.Stock.Indicators;

namespace TradingBot.Core.Domain.Chart
{
    public interface IIndicator
    {
        int MaxCountQuotes { get; }

        string Name { get; }

        IDictionary<DateTime, decimal?> Data { get; set; }

        decimal? this[int index] { get; }

        decimal? this[DateTime date] { get; }

        void Recalculate(IEnumerable<IQuote> quotes);

        IDictionary<DateTime, decimal?> Calculate(IEnumerable<IQuote> quotes);
    }
}
