using QuikSharp.DataStructures;
using TradingBot.Core.Converters.Exchange;

namespace TradingBot.Quik.Converters
{
    public class QuikIntervalConverter : BaseIntervalConverter<CandleInterval>
    {
        public override CandleInterval OneDay => CandleInterval.D1;

        public override CandleInterval OneHour => CandleInterval.H1;

        public override CandleInterval OneMinute => CandleInterval.M1;

        public override CandleInterval FiveMinutes => CandleInterval.M5;
    }
}
