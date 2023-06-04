using TradingBot.Core.Domain;
using TradingBot.Quik;

namespace TradingBot.TradeAdapters.Tests
{
    public class QuikTradeAdapterTests
    {
        private readonly ITradeAdapter _adapter;

        public QuikTradeAdapterTests(QuikSharp.Quik quik, QuikConverter converter)
        {
            _adapter = new QuikTradeAdapter(quik, converter);
        }

        [Fact]
        public async Task GetInstrument_WithParam_ReturnNotNullResult()
        {
            var symbol = new Symbol("GAZP", InstrumentType.Stock, new Currency("SUR"));

            var result = await _adapter.GetInstrument(symbol);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetTicker_WithInvalidParam_ThrowException()
        {
            var symbol = new Symbol("AAA", InstrumentType.Stock, new Currency("SUR"));

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
            var symbol = new Symbol("GAZP", InstrumentType.Stock, new Currency("SUR"));

            var result = await _adapter.GetHistoricalQuotes(symbol, Interval.OneDay,
                DateTime.UtcNow.AddMonths(-2), DateTime.UtcNow);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetPingAsync_ReturnResult()
        {
            var ping = await _adapter.GetPingAsync();

            Assert.True(ping > 0);
        }

        [Fact]
        public async Task SubscribeToPingChangedAsync_WithParams_ReceiveResult()
        {
            var receivedData = new List<long>();

            var onPingChangedHandler = receivedData.Add;

            var cancelTokenSource = new CancellationTokenSource();
            var token = cancelTokenSource.Token;

            await _adapter.SubscribeToPingChangedAsync(onPingChangedHandler, token);
            await Task.Delay(1000 * 3);

            cancelTokenSource.Cancel();
            cancelTokenSource.Dispose();

            Assert.NotNull(receivedData);
            Assert.NotEmpty(receivedData);
        }

        [Fact]
        public async Task GetServerTimeAsync_ReturnResult()
        {
            var time = await _adapter.GetServerTimeAsync();

            Assert.True(time > DateTime.UnixEpoch);
        }

        [Fact]
        public async Task SubscribeToServerTimeChangedAsync_WithParams_ReceiveResult()
        {
            var receivedData = new List<DateTime>();

            var onServerTimeChangedHandler = receivedData.Add;

            var cancelTokenSource = new CancellationTokenSource();
            var token = cancelTokenSource.Token;

            await _adapter.SubscribeToServerTimeChangedAsync(onServerTimeChangedHandler, token);
            await Task.Delay(1000 * 3);

            cancelTokenSource.Cancel();
            cancelTokenSource.Dispose();

            Assert.NotNull(receivedData);
            Assert.NotEmpty(receivedData);
        }
    }
}
