using Bybit.Net.Clients;
using TradingBot.Core.Domain;
using TradingBot.CryptoExchanges.ByBit;

namespace TradingBot.TradeAdapters.Tests
{
    public class ByBitTradeAdapterTests
    {
        private readonly ITradeAdapter _adapter;

        public ByBitTradeAdapterTests(BybitClient client, ByBitConverter converter)
        {
            _adapter = new ByBitTradeAdapter(client, converter);
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
