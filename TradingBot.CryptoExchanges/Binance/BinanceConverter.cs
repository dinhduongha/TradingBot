using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Binance.Net.Objects.Models.Spot;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.Binance
{
    public class BinanceConverter
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

        public IQuote ToQuote(IBinanceKline quote)
        {
            if (quote == null) throw new ArgumentNullException(nameof(quote));

            return new CustomQuote(quote.LowPrice, quote.OpenPrice, quote.HighPrice, quote.ClosePrice,
                quote.Volume, quote.OpenTime);
        }

        public StockTicker ToTicker(BinanceSymbol symbol)
        {
            if (symbol == null) throw new ArgumentNullException(nameof(symbol));

            return new StockTicker(symbol.Name, $"BINANCE {symbol.BaseAsset}/{symbol.QuoteAsset}",
                symbol.BaseAsset, StockExchange.Binance, InstrumentType.Spot, new Currency(symbol.QuoteAsset),
                    new LotFilter(symbol.LotSizeFilter?.StepSize), new PriceFilter(symbol?.PriceFilter?.TickSize));
        }
    }
}
