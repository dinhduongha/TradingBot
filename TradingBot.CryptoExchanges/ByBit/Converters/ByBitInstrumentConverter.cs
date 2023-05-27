using Bybit.Net.Objects.Models.V5;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.ByBit.Converters
{
    public class ByBitInstrumentConverter : BaseInstrumentConverter<BybitSpotSymbol>
    {
        public override string GetFullName(BybitSpotSymbol instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return $"{instrument.BaseAsset}/{instrument.QuoteAsset}";
        }

        public override StockExchange GetStockExchange(BybitSpotSymbol instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return StockExchange.ByBit;
        }

        public override InstrumentType GetInstrumentType(BybitSpotSymbol instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return InstrumentType.Spot;
        }

        public override Symbol GetSymbol(BybitSpotSymbol instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return new Symbol(instrument.BaseAsset, InstrumentType.Spot, new Currency(instrument.QuoteAsset));
        }

        public override LotFilter? GetLotFilter(BybitSpotSymbol instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            if (instrument.LotSizeFilter != null) return new LotFilter(instrument.LotSizeFilter.BasePrecision);
            else return null;
        }

        public override PriceFilter? GetPriceFilter(BybitSpotSymbol instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            if (instrument.PriceFilter != null) return new PriceFilter(instrument.PriceFilter.TickSize);
            else return null;
        }
    }
}
