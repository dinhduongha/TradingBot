using Bybit.Net.Objects.Models.V5;
using Skender.Stock.Indicators;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.ByBit.Converters
{
    public class ByBitQuoteConverter : IQuoteConverter<BybitKline>
    {
        public IQuote Convert(BybitKline input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new CustomQuote(input.LowPrice, input.OpenPrice, input.HighPrice, input.ClosePrice,
                input.Volume, input.StartTime);
        }
    }
}
