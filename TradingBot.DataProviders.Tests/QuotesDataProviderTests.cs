using Bybit.Net.Clients;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.CryptoExchanges.ByBit;
using TradingBot.TradeAdapters;

namespace TradingBot.DataProviders.Tests
{
    public class QuotesDataProviderTests
    {
        private readonly ITradeAdapter _adapter;

        public QuotesDataProviderTests(BybitClient httpClient, ByBitConverter converter)
        {
            _adapter = new ByBitTradeAdapter(httpClient, converter);
        }

        [Fact]
        public async Task Provide_WithParams_ReturnNotNullAndNotEmptyResult()
        {
            var result = new List<IQuote>();

            var symbol = new Symbol("ETH", InstrumentType.Spot, new Currency("USDT"));
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
