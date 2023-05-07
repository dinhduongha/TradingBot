using Okex.Net;

namespace TradingBot.TradeAdapters.Tests
{
    public class OkxTradeAdapterTests
    {
        private readonly ITradeAdapter _adapter;

        public OkxTradeAdapterTests(OkexClient client)
        {
            _adapter = new OkxTradeAdapter(client);
        }

        [Fact]
        public async Task GetTicker_WithParam_ReturnNotNullResult()
        {
            var result = await _adapter.GetTicker("ETH-USDT");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetTicker_WithInvalidParam_ThrowException()
        {
            var action = async () => await _adapter.GetTicker("AAA-USDT-SPOT");

            await Assert.ThrowsAsync<NotSupportedException>(action);
        }

        [Fact]
        public async Task GetTickers_ReturnNotNullAndNotEmptyResult()
        {
            var result = await _adapter.GetTickers();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
