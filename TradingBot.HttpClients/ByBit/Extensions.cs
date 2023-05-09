using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.ByBit
{
    public static class Extensions
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
                { Interval.TwoHours, KlineInterval.TwoHours },
                { Interval.FourHours, KlineInterval.FourHours },
                { Interval.OneDay, KlineInterval.OneDay },
                { Interval.OneWeek, KlineInterval.OneWeek },
                { Interval.OneMonth, KlineInterval.OneMonth }
            };

        public static KlineInterval MapInterval(this Interval interval)
        {
            return _intervals.ContainsKey(interval) ? _intervals[interval] : throw new KeyNotFoundException();
        }

        public static IQuote ToQuote(this BybitKline kline)
        {
            if (kline == null) throw new ArgumentNullException(nameof(kline));

            return new CustomQuote(kline.LowPrice, kline.OpenPrice, kline.HighPrice, kline.ClosePrice,
                kline.Volume, kline.StartTime);
        }

        public static StockTicker ToStockTicker(this BybitSpotSymbol symbol)
        {
            if (symbol == null) throw new ArgumentNullException(nameof(symbol));

            return new StockTicker(symbol.Name, $"BYBIT {symbol.BaseAsset}/{symbol.QuoteAsset}",
                symbol.BaseAsset, StockExchange.ByBit, InstrumentType.Spot, new Currency(symbol.QuoteAsset),
                    new LotFilter(symbol.LotSizeFilter?.BasePrecision), new PriceFilter(symbol?.PriceFilter?.TickSize));
        }
    }
}
