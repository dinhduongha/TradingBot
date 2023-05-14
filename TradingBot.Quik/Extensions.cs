using QuikSharp.DataStructures;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.Quik
{
    public static class Extensions
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

        public static IQuote ToQuote(this Candle candle)
        {
            if (candle == null) throw new ArgumentNullException(nameof(candle));

            return new CustomQuote(candle.Low, candle.Open, candle.High, candle.Close, candle.Volume,
                candle.Datetime.ToDateTime());
        }

        public static DateTime ToDateTime(this QuikDateTime dateTime)
        {
            if (dateTime == null) throw new ArgumentNullException(nameof(dateTime));

            return new DateTime(dateTime.year, dateTime.month, dateTime.day, dateTime.hour, dateTime.min,
                dateTime.sec, dateTime.ms, dateTime.mcs);
        }

        public static StockTicker ToStockTicker(this SecurityInfo info)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));

            return new StockTicker(info.ClassCode, info.Name, info.ShortName, StockExchange.Moex,
                InstrumentType.Stock, new Currency(info.FaceUnit), new LotFilter(info.LotSize),
                            new PriceFilter(Convert.ToDecimal(info.MinPriceStep)));
        }
    }
}
