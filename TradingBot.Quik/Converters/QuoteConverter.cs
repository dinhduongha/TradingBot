using QuikSharp.DataStructures;
using Skender.Stock.Indicators;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.Quik.Converters
{
    public class QuoteConverter : IQuoteConverter<Candle>
    {
        private readonly DateTimeConverter _dateTimeConverter;

        public QuoteConverter()
        {
            _dateTimeConverter = new DateTimeConverter();
        }

        public IQuote Convert(Candle input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new CustomQuote(input.Low, input.Open, input.High, input.Close, input.Volume,
                _dateTimeConverter.Convert(input.Datetime));
        }
    }
}
