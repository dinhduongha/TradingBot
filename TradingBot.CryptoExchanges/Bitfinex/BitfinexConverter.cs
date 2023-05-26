using Bitfinex.Net.Enums;
using Bitfinex.Net.Objects.Models;
using Bitfinex.Net.Objects.Models.V1;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.Bitfinex
{
    public class BitfinexConverter
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

        public IQuote ToQuote(BitfinexKline quote)
        {
            if (quote == null) throw new ArgumentNullException(nameof(quote));

            return new CustomQuote(quote.LowPrice, quote.OpenPrice, quote.HighPrice, quote.ClosePrice,
                quote.Volume, quote.OpenTime);
        }

        public StockTicker ToTicker(BitfinexSymbolDetails symbol)
        {
            if (symbol == null) throw new ArgumentNullException(nameof(symbol));

            throw new NotImplementedException();
        }
    }
}
