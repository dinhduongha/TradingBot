using QuikSharp.DataStructures;
using Skender.Stock.Indicators;
using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.Quik.Converters
{
    public class QuikQuoteConverter : IQuoteConverter<Candle>
    {
        private readonly QuikDateTimeConverter _dateTimeConverter;

        public QuikQuoteConverter()
        {
            _dateTimeConverter = new QuikDateTimeConverter();
        }

        public IQuote Convert(Candle input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new CustomQuote(input.Low, input.Open, input.High, input.Close, input.Volume,
                _dateTimeConverter.Convert(input.Datetime));
        }
    }
}
