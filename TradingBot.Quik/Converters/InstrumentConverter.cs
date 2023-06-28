using QuikSharp.DataStructures;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.Quik.Converters
{
    public class InstrumentConverter : BaseInstrumentConverter<SecurityInfo>
    {
        public override string GetFullName(SecurityInfo instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return instrument.Name;
        }

        public override StockExchange GetStockExchange(SecurityInfo instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            if (instrument.ClassCode == "TQBR") return StockExchange.Moex;
            else if (instrument.ClassCode == "SPBXM") return StockExchange.Spbex;
            else return StockExchange.Undefined;
        }

        public override InstrumentType GetInstrumentType(SecurityInfo instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return InstrumentType.Stock;
        }

        public override Symbol GetSymbol(SecurityInfo instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return new Symbol(instrument.SecCode, InstrumentType.Stock, new Currency(instrument.FaceUnit));
        }

        public override LotFilter? GetLotFilter(SecurityInfo instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return new LotFilter(instrument.LotSize);
        }

        public override PriceFilter? GetPriceFilter(SecurityInfo instrument)
        {
            if (instrument == null) throw new ArgumentNullException(nameof(instrument));

            return new PriceFilter(System.Convert.ToDecimal(instrument.MinPriceStep));
        }
    }
}
