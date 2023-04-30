using Skender.Stock.Indicators;

namespace TradingBot.Core.Domain.Chart
{
    public interface IChart
    {
        int MaxCountQuotes { get; }

        IDictionary<DateTime, IQuote> Quotes { get; }

        IEnumerable<IIndicator> Indicators { get; }

        ChartDataItem this[int index] { get; }

        ChartDataItem this[DateTime startedAt] { get; }

        IEnumerable<ChartDataItem> ChartDataItems { get; }

        void Add(IQuote quote);
    }
}
