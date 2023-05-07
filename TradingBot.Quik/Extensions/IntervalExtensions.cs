using QuikSharp.DataStructures;
using TradingBot.Core.Domain;

namespace TradingBot.Quik.Extensions
{
    public static class IntervalExtensions
    {
        private static readonly Dictionary<Interval, CandleInterval> _intervals =
            new Dictionary<Interval, CandleInterval>()
            {
                { Interval.OneMinute, CandleInterval.M1 },
                { Interval.ThreeMinutes, CandleInterval.M3 },
                { Interval.FiveMinutes, CandleInterval.M5 },
                { Interval.FifteenMinutes, CandleInterval.M15 },
                { Interval.ThirtyMinutes, CandleInterval.M30 },
                { Interval.OneHour, CandleInterval.H1 },
                { Interval.TwoHours, CandleInterval.H2 },
                { Interval.FourHours, CandleInterval.H4 },
                { Interval.OneDay, CandleInterval.D1 },
                { Interval.OneWeek, CandleInterval.W1 },
                { Interval.OneMonth, CandleInterval.MN }
            };

        public static CandleInterval MapInterval(this Interval interval)
        {
            return _intervals.ContainsKey(interval) ? _intervals[interval] : throw new KeyNotFoundException();
        }
    }
}
