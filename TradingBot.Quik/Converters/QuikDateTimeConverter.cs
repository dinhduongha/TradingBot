using QuikSharp.DataStructures;
using TradingBot.Core.Converters.Exchange;

namespace TradingBot.Quik.Converters
{
    public class QuikDateTimeConverter : IDateTimeConverter<QuikDateTime>
    {
        public DateTime Convert(QuikDateTime input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new DateTime(input.year, input.month, input.day, input.hour, input.min,
                input.sec, input.ms, input.mcs);
        }
    }
}
