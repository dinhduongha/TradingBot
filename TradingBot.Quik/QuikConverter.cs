using QuikSharp.DataStructures;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.Quik
{
    public class QuikConverter
    {
        private Dictionary<Interval, CandleInterval> _intervals => new Dictionary<Interval, CandleInterval>()
        {
            { Interval.OneMinute, CandleInterval.M1 },
            { Interval.FiveMinutes, CandleInterval.M5 },
            { Interval.OneHour, CandleInterval.H1 },
            { Interval.OneDay, CandleInterval.D1 },
        };

        public CandleInterval ToInterval(Interval interval)
        {
            return _intervals[interval];
        }

        public IQuote ToQuote(Candle candle)
        {
            if (candle == null) throw new ArgumentNullException(nameof(candle));

            return new CustomQuote(candle.Low, candle.Open, candle.High, candle.Close, candle.Volume,
                ToDateTime(candle.Datetime));
        }

        public StockTicker ToTicker(SecurityInfo info)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));

            return new StockTicker(info.ClassCode, info.Name, info.ShortName, StockExchange.Moex,
                InstrumentType.Stock, new Currency(info.FaceUnit), new LotFilter(info.LotSize),
                            new PriceFilter(Convert.ToDecimal(info.MinPriceStep)));
        }

        public DateTime ToDateTime(QuikDateTime dateTime)
        {
            if (dateTime == null) throw new ArgumentNullException(nameof(dateTime));

            return new DateTime(dateTime.year, dateTime.month, dateTime.day, dateTime.hour, dateTime.min,
                dateTime.sec, dateTime.ms, dateTime.mcs);
        }
    }
}
