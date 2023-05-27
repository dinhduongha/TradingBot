using Bitfinex.Net.Objects.Models;
using Skender.Stock.Indicators;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.Bitfinex.Converters
{
    public class BitfinexQuoteConverter : IQuoteConverter<BitfinexKline>
    {
        public IQuote Convert(BitfinexKline input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new CustomQuote(input.LowPrice, input.OpenPrice, input.HighPrice, input.ClosePrice,
                input.Volume, input.OpenTime);
        }
    }
}
