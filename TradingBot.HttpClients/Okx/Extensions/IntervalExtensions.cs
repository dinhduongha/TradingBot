using Okex.Net.Enums;
using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.Okx.Extensions
{
    public static class IntervalExtensions
    {
        private static readonly Dictionary<Interval, OkexPeriod> _intervals =
            new Dictionary<Interval, OkexPeriod>()
            {
                { Interval.OneMinute, OkexPeriod.OneMinute },
                { Interval.ThreeMinutes, OkexPeriod.ThreeMinutes },
                { Interval.FiveMinutes, OkexPeriod.FiveMinutes },
                { Interval.FifteenMinutes, OkexPeriod.FifteenMinutes },
                { Interval.ThirtyMinutes, OkexPeriod.ThirtyMinutes },
                { Interval.OneHour, OkexPeriod.OneHour },
                { Interval.TwoHours, OkexPeriod.TwoHours },
                { Interval.FourHours, OkexPeriod.FourHours },
                { Interval.OneDay, OkexPeriod.OneDay },
                { Interval.OneWeek, OkexPeriod.OneWeek },
                { Interval.OneMonth, OkexPeriod.OneMonth }
            };

        public static OkexPeriod MapInterval(this Interval interval)
        {
            return _intervals.ContainsKey(interval) ? _intervals[interval] : throw new KeyNotFoundException();
        }
    }
}
