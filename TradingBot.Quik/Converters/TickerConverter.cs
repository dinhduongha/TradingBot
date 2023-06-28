using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.Quik.Converters
{
    public class TickerConverter : ITickerConverter
    {
        public string Convert(Symbol input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return $"{input.InstrumentCode}";
        }
    }
}
