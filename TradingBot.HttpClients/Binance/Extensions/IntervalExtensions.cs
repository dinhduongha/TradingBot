using Binance.Net.Enums;
using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.Binance.Extensions
{
    public static class IntervalExtensions
    {
        private static readonly Dictionary<Interval, KlineInterval> _intervals =
            new Dictionary<Interval, KlineInterval>()
            {
                { Interval.OneMinute, KlineInterval.OneMinute },
                { Interval.ThreeMinutes, KlineInterval.ThreeMinutes },
                { Interval.FiveMinutes, KlineInterval.FiveMinutes },
                { Interval.FifteenMinutes, KlineInterval.FifteenMinutes },
                { Interval.ThirtyMinutes, KlineInterval.ThirtyMinutes },
                { Interval.OneHour, KlineInterval.OneHour },
                { Interval.TwoHours, KlineInterval.TwoHour },
                { Interval.FourHours, KlineInterval.FourHour },
                { Interval.OneDay, KlineInterval.OneDay },
                { Interval.OneWeek, KlineInterval.OneWeek },
                { Interval.OneMonth, KlineInterval.OneMonth }
            };

        public static KlineInterval MapInterval(this Interval interval)
        {
            return _intervals.ContainsKey(interval) ? _intervals[interval] : throw new KeyNotFoundException();
        }
    }
}
