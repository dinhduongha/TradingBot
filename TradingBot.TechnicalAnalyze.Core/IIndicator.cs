using Skender.Stock.Indicators;

namespace TradingBot.TechnicalAnalyze.Core
{
    public interface IIndicator
    {
        int MaxCountQuotes { get; }

        string Name { get; }

        IDictionary<DateTime, double?> Data { get; set; }

        double? this[int index] { get; }

        double? this[DateTime date] { get; }

        void Recalculate(IEnumerable<IQuote> quotes);

        IDictionary<DateTime, double?> Calculate(IEnumerable<IQuote> quotes);
    }
}
