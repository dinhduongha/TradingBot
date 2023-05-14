namespace TradingBot.Core.Domain
{
    public class StockTicker
    {
        public string Code { get; }

        public string FullName { get; }

        public string ShortName { get; }

        public StockExchange StockExchange { get; }

        public InstrumentType InstrumentType { get; }

        public Currency Currency { get; }

        public LotFilter LotFilter { get; }

        public PriceFilter PriceFilter { get; }

        public StockTicker(string code, string fullName, string shortName, StockExchange stockExchange, 
            InstrumentType instrumentType, Currency currency, LotFilter lotFilter, PriceFilter priceFilter)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));
            if (string.IsNullOrEmpty(fullName)) throw new ArgumentNullException(nameof(fullName));
            if (string.IsNullOrEmpty(shortName)) throw new ArgumentNullException(nameof(shortName));
            if (currency == null) throw new ArgumentNullException(nameof(currency));
            if (lotFilter == null) throw new ArgumentNullException(nameof(lotFilter));
            if (priceFilter == null) throw new ArgumentNullException(nameof(priceFilter));

            Code = code;
            FullName = fullName;
            ShortName = shortName;
            StockExchange = stockExchange;
            InstrumentType = instrumentType;
            Currency = currency;
            LotFilter = lotFilter;
            PriceFilter = priceFilter;
        }
    }
}
