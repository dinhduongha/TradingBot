using Binance.Net.Objects.Models.Spot;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.Binance.Converters
{
    public class BinanceInstrumentConverter : BaseInstrumentConverter<BinanceSymbol>
    {
        public override string GetFullName(BinanceSymbol instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return $"{instrument.BaseAsset}/{instrument.QuoteAsset}";
        }

        public override StockExchange GetStockExchange(BinanceSymbol instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return StockExchange.Binance;
        }

        public override InstrumentType GetInstrumentType(BinanceSymbol instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return InstrumentType.Spot;
        }

        public override Symbol GetSymbol(BinanceSymbol instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return new Symbol(instrument.BaseAsset, InstrumentType.Spot, new Currency(instrument.QuoteAsset));
        }

        public override LotFilter? GetLotFilter(BinanceSymbol instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            if (instrument.LotSizeFilter != null) return new LotFilter(instrument.LotSizeFilter.StepSize);
            else return null;
        }

        public override PriceFilter? GetPriceFilter(BinanceSymbol instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            if (instrument.PriceFilter != null) return new PriceFilter(instrument.PriceFilter.TickSize);
            else return null;
        }
    }
}
