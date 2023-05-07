using QuikSharp.DataStructures;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.Quik.Extensions
{
    public static class CandleExtensions
    {
        public static IQuote ToQuote(this Candle candle)
        {
            if (candle == null) throw new ArgumentNullException(nameof(candle));

            return new CustomQuote(candle.Low, candle.Open, candle.High, candle.Close, candle.Volume, 
                new DateTime(candle.Datetime.year, candle.Datetime.month, candle.Datetime.day, 
                    candle.Datetime.hour, candle.Datetime.min, candle.Datetime.sec, candle.Datetime.ms, 
                        candle.Datetime.mcs));
        }
    }
}
