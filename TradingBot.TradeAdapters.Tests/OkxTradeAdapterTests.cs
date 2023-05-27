using Okex.Net;
using TradingBot.Core.Domain;
using TradingBot.CryptoExchanges.Okx;

namespace TradingBot.TradeAdapters.Tests
{
    public class OkxTradeAdapterTests
    {
        private readonly ITradeAdapter _adapter;

        public OkxTradeAdapterTests(OkexClient client, OkxConverter converter)
        {
            _adapter = new OkxTradeAdapter(client, converter);
        }

        [Fact]
        public async Task GetInstrument_WithParam_ReturnNotNullResult()
        {
            var symbol = new Symbol("ETH", InstrumentType.Spot, new Currency("USDT"));

            var result = await _adapter.GetInstrument(symbol);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetInstrument_WithInvalidParam_ThrowException()
        {
            var symbol = new Symbol("AAA", InstrumentType.Spot, new Currency("USDT"));

            var action = async () => await _adapter.GetInstrument(symbol);

            await Assert.ThrowsAsync<NotSupportedException>(action);
        }

        [Fact]
        public async Task GetInstruments_ReturnNotNullAndNotEmptyResult()
        {
            var result = await _adapter.GetInstruments();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetHistoricalQuotes_WithParams_ReturnNotNullAndNotEmptyResult()
        {
            var symbol = new Symbol("ETH", InstrumentType.Spot, new Currency("USDT"));

            var result = await _adapter.GetHistoricalQuotes(symbol, Interval.OneDay,
                DateTime.UtcNow.AddMonths(-2), DateTime.UtcNow);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
