using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.ByBit.RequestModels
{
    public class GetKlineRequestModel
    {
        public int Limit { get; }

        public long End { get; }

        public long Start { get; }

        public string Symbol { get; }

        public string Category { get; }

        public string Interval { get; }

        public GetKlineRequestModel(Category category, string symbol, Interval interval, 
            DateTime start, DateTime end, int limit = 200)
        {
            if (string.IsNullOrEmpty(symbol)) throw new ArgumentNullException(nameof(symbol));
            if (start > end) throw new ArgumentOutOfRangeException(nameof(start));
            if (end < start) throw new ArgumentOutOfRangeException(nameof(end));
            if (limit <= 0 || limit > 200) throw new ArgumentOutOfRangeException(nameof(limit));

            Limit = limit;
            End = new DateTimeOffset(end).ToUnixTimeMilliseconds();
            Start = new DateTimeOffset(start).ToUnixTimeMilliseconds();
            Symbol = symbol;
            Category = ByBitDictionaries.Categories[category];
            Interval = ByBitDictionaries.Intervals[interval];
        }
    }
}
