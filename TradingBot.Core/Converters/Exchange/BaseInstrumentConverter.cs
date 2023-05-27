using TradingBot.Core.Domain;

namespace TradingBot.Core.Converters.Exchange
{
    public abstract class BaseInstrumentConverter<TInstrument> : IInstrumentConverter<TInstrument>
    {
        public Instrument Convert(TInstrument input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new Instrument(GetSymbol(input), GetFullName(input), GetInstrumentType(input),
                GetStockExchange(input), GetLotFilter(input), GetPriceFilter(input));
        }

        public abstract string GetFullName(TInstrument instrument);

        public abstract StockExchange GetStockExchange(TInstrument instrument);

        public abstract InstrumentType GetInstrumentType(TInstrument instrument);

        public abstract Symbol GetSymbol(TInstrument instrument);

        public abstract LotFilter? GetLotFilter(TInstrument instrument);

        public abstract PriceFilter? GetPriceFilter(TInstrument instrument);
    }
}
