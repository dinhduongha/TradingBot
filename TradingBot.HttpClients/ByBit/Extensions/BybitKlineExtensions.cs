using Bybit.Net.Objects.Models.V5;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.ByBit.Extensions
{
    public static class BybitKlineExtensions
    {
        public static IQuote ToQuote(this BybitKline kline)
        {
            if (kline == null) throw new ArgumentNullException(nameof(kline));

            return new CustomQuote(kline.LowPrice, kline.OpenPrice, kline.HighPrice, kline.ClosePrice,
                kline.Volume, kline.StartTime);
        }
    }
}
