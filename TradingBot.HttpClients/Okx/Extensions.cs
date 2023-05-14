using Okex.Net.Enums;
using Okex.Net.Objects.Market;
using Okex.Net.Objects.Public;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.Okx
{
    public static class Extensions
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

        public static IQuote ToQuote(this OkexCandlestick candlestick)
        {
            if (candlestick == null) throw new ArgumentNullException(nameof(candlestick));

            return new CustomQuote(candlestick.Low, candlestick.Open, candlestick.High, candlestick.Close,
                candlestick.Volume, candlestick.Time);
        }

        public static StockTicker ToStockTicker(this OkexInstrument instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return new StockTicker(instrument.Instrument, $"OKX {instrument.BaseCurrency}/{instrument.QuoteCurrency}",
                instrument.BaseCurrency, StockExchange.Okx, InstrumentType.Spot, new Currency(instrument.QuoteCurrency),
                    new LotFilter(instrument.LotSize), new PriceFilter(instrument.MinimumOrderSize));
        }
    }
}
