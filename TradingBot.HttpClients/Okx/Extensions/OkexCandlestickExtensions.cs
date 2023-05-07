using Okex.Net.Objects.Market;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.Okx.Extensions
{
    public static class OkexCandlestickExtensions
    {
        public static IQuote ToQuote(this OkexCandlestick candlestick)
        {
            if (candlestick == null) throw new ArgumentNullException(nameof(candlestick));

            return new CustomQuote(candlestick.Low, candlestick.Open, candlestick.High, candlestick.Close, 
                candlestick.Volume, candlestick.Time);
        }
    }
}
