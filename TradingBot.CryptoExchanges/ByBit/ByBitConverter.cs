using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.ByBit
{
    public class ByBitConverter
    {
        private Dictionary<Interval, KlineInterval> _intervals => new Dictionary<Interval, KlineInterval>()
        {
            { Interval.OneMinute, KlineInterval.OneMinute },
            { Interval.FiveMinutes, KlineInterval.FiveMinutes },
            { Interval.OneHour, KlineInterval.OneHour },
            { Interval.OneDay, KlineInterval.OneDay },
        };

        public KlineInterval ToInterval(Interval interval)
        {
            return _intervals[interval];
        }

        public IQuote ToQuote(BybitKline quote)
        {
            if (quote == null) throw new ArgumentNullException(nameof(quote));

            return new CustomQuote(quote.LowPrice, quote.OpenPrice, quote.HighPrice, quote.ClosePrice,
                quote.Volume, quote.StartTime);
        }

        public StockTicker ToTicker(BybitSpotSymbol symbol)
        {
            if (symbol == null) throw new ArgumentNullException(nameof(symbol));

            return new StockTicker(symbol.Name, $"BYBIT {symbol.BaseAsset}/{symbol.QuoteAsset}",
                symbol.BaseAsset, StockExchange.ByBit, InstrumentType.Spot, new Currency(symbol.QuoteAsset),
                    new LotFilter(symbol.LotSizeFilter?.BasePrecision), new PriceFilter(symbol?.PriceFilter?.TickSize));
        }
    }
}
