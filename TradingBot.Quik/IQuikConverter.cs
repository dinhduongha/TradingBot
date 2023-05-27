using QuikSharp.DataStructures;
using TradingBot.Core.Converters.Exchange;

namespace TradingBot.Quik
{
    public interface IQuikConverter : IExchangeConverter<Candle, SecurityInfo, CandleInterval>
    {
        IDateTimeConverter<QuikDateTime> DateTime { get; }
    }
}
