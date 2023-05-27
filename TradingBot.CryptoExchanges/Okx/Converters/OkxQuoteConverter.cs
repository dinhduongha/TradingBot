using Okex.Net.Objects.Market;
using Skender.Stock.Indicators;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.Okx.Converters
{
    public class OkxQuoteConverter : IQuoteConverter<OkexCandlestick>
    {
        public IQuote Convert(OkexCandlestick input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new CustomQuote(input.Low, input.Open, input.High, input.Close,
                input.Volume, input.Time);
        }
    }
}
