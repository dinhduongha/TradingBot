using Skender.Stock.Indicators;
using TradingBot.Core.Extensions;

namespace TradingBot.Core.Domain.Chart.Indicators
{
    public class Bop : Indicator
    {
        public override string Name => "BOP";

        public Bop(IEnumerable<IQuote> quotes)
        {
            Recalculate(quotes);
        }

        public override IDictionary<DateTime, decimal?> Calculate(IEnumerable<IQuote> quotes)
        {
            return quotes.GetBop().ToDictionary(data => data.Date, data => data.Bop.ToDecimal());
        }
    }
}
