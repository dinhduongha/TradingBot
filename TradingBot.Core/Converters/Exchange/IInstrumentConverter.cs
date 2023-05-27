using TradingBot.Core.Abstracts;
using TradingBot.Core.Domain;

namespace TradingBot.Core.Converters.Exchange
{
    public interface IInstrumentConverter<TInstrument> : IConverter<TInstrument, Instrument>
    {
        string GetFullName(TInstrument instrument);

        InstrumentType GetInstrumentType(TInstrument instrument);

        StockExchange GetStockExchange(TInstrument instrument);

        Symbol GetSymbol(TInstrument instrument);

        LotFilter? GetLotFilter(TInstrument instrument);

        PriceFilter? GetPriceFilter(TInstrument instrument);
    }
}
