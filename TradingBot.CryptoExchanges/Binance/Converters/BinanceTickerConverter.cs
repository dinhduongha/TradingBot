using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.Binance.Converters
{
    public class BinanceTickerConverter : ITickerConverter
    {
        public string Convert(Symbol input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return $"{input.InstrumentCode}{input.Currency?.Name ?? ""}";
        }
    }
}
