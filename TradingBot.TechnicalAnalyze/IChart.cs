using Skender.Stock.Indicators;

namespace TradingBot.TechnicalAnalyze
{
    public interface IChart
    {
        int MaxCountQuotes { get; }

        IDictionary<DateTime, IQuote> Quotes { get; }

        IEnumerable<IIndicator> Indicators { get; }

        ChartDataItem this[int index] { get; }

        ChartDataItem this[DateTime startedAt] { get; }

        void Add(IQuote quote);
    }
}
