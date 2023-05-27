using Binance.Net.Clients;
using TradingBot.Core.Domain;
using TradingBot.CryptoExchanges.Binance;

namespace TradingBot.TradeAdapters.Tests
{
    public class BinanceTradeAdapterTests
    {
        private readonly ITradeAdapter _adapter;

        public BinanceTradeAdapterTests(BinanceClient client, BinanceConverter converter)
        {
            _adapter = new BinanceTradeAdapter(client, converter);
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
