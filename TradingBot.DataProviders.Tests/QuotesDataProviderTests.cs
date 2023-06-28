using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.Quik;
using TradingBot.TradeAdapters;

namespace TradingBot.DataProviders.Tests
{
    public class QuotesDataProviderTests
    {
        private readonly ITradeAdapter _adapter;

        public QuotesDataProviderTests(QuikSharp.Quik quik, QuikConverter converter)
        {
            _adapter = new QuikTradeAdapter(quik, converter);
        }

        [Fact]
        public async Task Provide_WithParams_ReturnNotNullAndNotEmptyResult()
        {
            var result = new List<IQuote>();

            var symbol = new Symbol("GAZP", InstrumentType.Stock, new Currency("SUR"));
            var provider = new QuotesDataProvider(DateTime.UtcNow.AddDays(-3), DateTime.UtcNow,
                Interval.FiveMinutes, _adapter);

            await foreach (var quote in provider.Provide(symbol))
            {
                result.Add(quote);
            }

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
