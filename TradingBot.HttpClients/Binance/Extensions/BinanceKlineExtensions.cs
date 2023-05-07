using Binance.Net.Interfaces;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.Binance.Extensions
{
    public static class BinanceKlineExtensions
    {
        public static IQuote ToQuote(this IBinanceKline kline)
        {
            if (kline == null) throw new ArgumentNullException(nameof(kline));

            return new CustomQuote(kline.LowPrice, kline.OpenPrice, kline.HighPrice, kline.ClosePrice,
                kline.Volume, kline.OpenTime);
        }
    }
}
