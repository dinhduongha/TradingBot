using Okex.Net.Objects.Public;
using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.Okx.Extensions
{
    public static class OkexInstrumentExtensions
    {
        public static StockTicker ToStockTicker(this OkexInstrument instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return new StockTicker(instrument.Instrument, $"OKX {instrument.BaseCurrency}/{instrument.QuoteCurrency}",
                instrument.BaseCurrency, StockExchange.Okx, InstrumentType.Spot, new Currency(instrument.QuoteCurrency),
                    new LotFilter(instrument.LotSize), new PriceFilter(instrument.MinimumOrderSize));
        }
    }
}
