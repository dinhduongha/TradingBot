using Binance.Net.Interfaces;
using Skender.Stock.Indicators;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.CryptoExchanges.Binance.Converters
{
    public class BinanceQuoteConverter : IQuoteConverter<IBinanceKline>
    {
        public IQuote Convert(IBinanceKline input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new CustomQuote(input.LowPrice, input.OpenPrice, input.HighPrice, input.ClosePrice,
                input.Volume, input.OpenTime);
        }
    }
}
