using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Binance.Net.Objects.Models.Spot;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.Binance
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

        public static IQuote ToQuote(this IBinanceKline kline)
        {
            if (kline == null) throw new ArgumentNullException(nameof(kline));

            return new CustomQuote(kline.LowPrice, kline.OpenPrice, kline.HighPrice, kline.ClosePrice,
                kline.Volume, kline.OpenTime);
        }

        public static StockTicker ToStockTicker(this BinanceSymbol symbol)
        {
            if (symbol == null) throw new ArgumentNullException(nameof(symbol));

            return new StockTicker(symbol.Name, $"BINANCE {symbol.BaseAsset}/{symbol.QuoteAsset}",
                symbol.BaseAsset, StockExchange.Binance, InstrumentType.Spot, new Currency(symbol.QuoteAsset),
                    new LotFilter(symbol.LotSizeFilter?.StepSize), new PriceFilter(symbol?.PriceFilter?.TickSize));
        }
    }
}
