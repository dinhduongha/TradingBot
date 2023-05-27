using Okex.Net.Objects.Public;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.Okx.Converters
{
    public class OkxInstrumentConverter : BaseInstrumentConverter<OkexInstrument>
    {
        public override string GetFullName(OkexInstrument instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return $"{instrument.BaseCurrency}/{instrument.QuoteCurrency}";
        }

        public override StockExchange GetStockExchange(OkexInstrument instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return StockExchange.Okx;
        }

        public override InstrumentType GetInstrumentType(OkexInstrument instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return InstrumentType.Spot;
        }

        public override Symbol GetSymbol(OkexInstrument instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return new Symbol(instrument.BaseCurrency, InstrumentType.Spot, new Currency(instrument.QuoteCurrency));
        }

        public override LotFilter? GetLotFilter(OkexInstrument instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return new LotFilter(instrument.LotSize);
        }

        public override PriceFilter? GetPriceFilter(OkexInstrument instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return new PriceFilter(instrument.MinimumOrderSize);
        }
    }
}
