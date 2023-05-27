using TradingBot.Core.Domain;

namespace TradingBot.Core.Converters.Exchange
{
    public abstract class BaseIntervalConverter<TInterval> : IIntervalConverter<TInterval>
    {
        private readonly IDictionary<Interval, TInterval> _intervals;

        public abstract TInterval OneDay { get; }

        public abstract TInterval OneHour { get; }

        public abstract TInterval OneMinute { get; }

        public abstract TInterval FiveMinutes { get; }

        public BaseIntervalConverter()
        {
            _intervals = new Dictionary<Interval, TInterval>
            {
                { Interval.OneDay, OneDay },
                { Interval.OneHour, OneHour },
                { Interval.OneMinute, OneMinute },
                { Interval.FiveMinutes, FiveMinutes },
            };
        }

        public TInterval Convert(Interval interval)
        {
            return _intervals.ContainsKey(interval) ? _intervals[interval] : throw new NotSupportedException();
        }
    }
}
