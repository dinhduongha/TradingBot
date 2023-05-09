using Bybit.Net.Clients;
using TradingBot.TradeAdapters;

namespace TradingBot.DataProviders.Tests
{
    public class TickersDataProviderTests
    {
        private readonly ITickersDataProvider _provider;

        public TickersDataProviderTests(BybitClient httpClient)
        {
            _provider = new TickersDataProvider(new ByBitTradeAdapter(httpClient));
        }

        [Fact]
        public async Task ProvideAsync_ReturnNotNullAndNotEmptyResult()
        {
            var result = await _provider.ProvideAsync();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
