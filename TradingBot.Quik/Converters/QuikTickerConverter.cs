using QuikSharp.DataStructures;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.Quik.Converters
{
    public class QuikTickerConverter : ITickerConverter<SecurityInfo>
    {
        public StockTicker Convert(SecurityInfo input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new StockTicker(input.ClassCode, input.Name, input.ShortName, StockExchange.Moex,
                InstrumentType.Stock, new Currency(input.FaceUnit), new LotFilter(input.LotSize),
                            new PriceFilter(System.Convert.ToDecimal(input.MinPriceStep)));
        }
    }
}
