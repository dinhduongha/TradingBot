namespace TradingBot.Core.Domain
{
    public class Instrument
    {
        public string Code { get; }

        public string FullName { get; }

        public InstrumentType Type { get; }

        public StockExchange StockExchange { get; }

        public Symbol Symbol { get; }

        public Currency? Currency { get; }

        public LotFilter? LotFilter { get; }

        public PriceFilter? PriceFilter { get; }

        public Instrument(Symbol symbol, string fullName, InstrumentType type, StockExchange stockExchange, 
            LotFilter? lotFilter = null, PriceFilter? priceFilter = null)
        {
            if (symbol == null) throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(fullName)) throw new ArgumentNullException(nameof(fullName));

            Code = symbol.InstrumentCode;
            FullName = fullName;
            Type = type;
            StockExchange = stockExchange;
            Symbol = symbol;
            Currency = symbol.Currency;
            LotFilter = lotFilter;
            PriceFilter = priceFilter;
        }
    }
}
