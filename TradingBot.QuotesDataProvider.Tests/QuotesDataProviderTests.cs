using Bybit.Net.Clients;
using TradingBot.Core.Domain;
using TradingBot.TradeAdapters;

namespace TradingBot.QuotesDataProvider.Tests
{
    public class QuotesDataProviderTests
    {
        private readonly ITradeAdapter _adapter;

        public QuotesDataProviderTests(BybitClient httpClient)
        {
            _adapter = new ByBitTradeAdapter(httpClient);
        }

        [Fact]
        public async Task ProvideAsync_WithParams_ReturnNotNullResult()
        {
            var downloader = new QuotesDataProvider(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow,
                Interval.OneMinute, _adapter);

            var result = await downloader.ProvideAsync();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
