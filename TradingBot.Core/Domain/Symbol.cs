namespace TradingBot.Core.Domain
{
    public class Symbol
    {
        public string InstrumentCode { get; }

        public InstrumentType InstrumentType { get; }

        public Currency? Currency { get; }

        public Symbol(string instrumentCode, InstrumentType instrumentType, Currency? currency = null)
        {
            if (string.IsNullOrEmpty(instrumentCode)) throw new ArgumentNullException(nameof(instrumentCode));

            InstrumentCode = instrumentCode;
            InstrumentType = instrumentType;
            Currency = currency;
        }
    }
}
