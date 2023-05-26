using Okex.Net.Enums;
using Okex.Net.Objects.Market;
using Okex.Net.Objects.Public;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.Okx
{
    public class OkxConverter
    {
        private Dictionary<Interval, OkexPeriod> _intervals => new Dictionary<Interval, OkexPeriod>()
        {
            { Interval.OneMinute, OkexPeriod.OneMinute },
            { Interval.FiveMinutes, OkexPeriod.FiveMinutes },
            { Interval.OneHour, OkexPeriod.OneHour },
            { Interval.OneDay, OkexPeriod.OneDay },
        };

        public OkexPeriod ToInterval(Interval interval)
        {
            return _intervals[interval];
        }

        public IQuote ToQuote(OkexCandlestick candlestick)
        {
            if (candlestick == null) throw new ArgumentNullException(nameof(candlestick));

            return new CustomQuote(candlestick.Low, candlestick.Open, candlestick.High, candlestick.Close,
                candlestick.Volume, candlestick.Time);
        }

        public StockTicker ToTicker(OkexInstrument instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return new StockTicker(instrument.Instrument, $"OKX {instrument.BaseCurrency}/{instrument.QuoteCurrency}",
                instrument.BaseCurrency, StockExchange.Okx, InstrumentType.Spot, new Currency(instrument.QuoteCurrency),
                    new LotFilter(instrument.LotSize), new PriceFilter(instrument.MinimumOrderSize));
        }
    }
}
