using Okex.Net.Objects.Public;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.Okx.Converters
{
    public class OkxTickerConverter : ITickerConverter<OkexInstrument>
    {
        public StockTicker Convert(OkexInstrument input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new StockTicker(input.Instrument, $"OKX {input.BaseCurrency}/{input.QuoteCurrency}",
                input.BaseCurrency, StockExchange.Okx, InstrumentType.Spot, new Currency(input.QuoteCurrency),
                    new LotFilter(input.LotSize), new PriceFilter(input.MinimumOrderSize));
        }
    }
}
