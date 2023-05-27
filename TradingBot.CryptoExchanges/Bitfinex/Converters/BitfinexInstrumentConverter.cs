using Bitfinex.Net.Objects.Models.V1;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.Bitfinex.Converters
{
    public class BitfinexInstrumentConverter : BaseInstrumentConverter<BitfinexSymbolDetails>
    {
        public override string GetFullName(BitfinexSymbolDetails instrument)
        {
            throw new NotImplementedException();
        }

        public override StockExchange GetStockExchange(BitfinexSymbolDetails instrument)
        {
            throw new NotImplementedException();
        }

        public override InstrumentType GetInstrumentType(BitfinexSymbolDetails instrument)
        {
            throw new NotImplementedException();
        }

        public override Symbol GetSymbol(BitfinexSymbolDetails instrument)
        {
            throw new NotImplementedException();
        }

        public override LotFilter? GetLotFilter(BitfinexSymbolDetails instrument)
        {
            throw new NotImplementedException();
        }

        public override PriceFilter? GetPriceFilter(BitfinexSymbolDetails instrument)
        {
            throw new NotImplementedException();
        }
    }
}
