using QuikSharp.DataStructures;
using TradingBot.Core.Converters.Exchange;

namespace TradingBot.Quik
{
    public interface IQuikConverter : IExchangeConverter<Candle, SecurityInfo, CandleInterval, OrderBook>
    {
        IDateTimeConverter<QuikDateTime> DateTime { get; }
    }
}
