using Bitfinex.Net.Objects.Models.V1;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.Bitfinex.Converters
{
    public class BitfinexTickerConverter : ITickerConverter<BitfinexSymbolDetails>
    {
        public StockTicker Convert(BitfinexSymbolDetails input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            throw new NotImplementedException();
        }
    }
}
