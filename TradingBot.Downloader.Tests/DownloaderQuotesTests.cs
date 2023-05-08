using Bybit.Net.Clients;
using TradingBot.Core.Domain;
using TradingBot.TradeAdapters;

namespace TradingBot.Downloader.Tests
{
    public class DownloaderQuotesTests
    {
        private readonly ITradeAdapter _adapter;

        public DownloaderQuotesTests(BybitClient httpClient)
        {
            _adapter = new ByBitTradeAdapter(httpClient);
        }

        [Fact]
        public async Task DownloaderQuotesConstructor_WithParams_ReturnNotNullResult()
        {
            var downloader = new DownloaderQuotes(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow,
                Interval.OneMinute, _adapter);

            var result = await downloader.DownloadAsync();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
