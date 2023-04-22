using Bybit.Net.Clients;
using Bybit.Net.Enums;

namespace TradingBot.Downloader.Tests
{
    public class DownloaderSpotKlinesTests
    {
        private readonly BybitClient _httpClient;

        public DownloaderSpotKlinesTests(BybitClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Fact]
        public async Task DownloaderSpotKlinesConstructor_WithParams_ReturnNotNullResult()
        {
            var downloader = new DownloaderSpotKlines(DateTime.UtcNow.AddMonths(-2).AddDays(-3), DateTime.UtcNow,
                KlineInterval.OneDay, _httpClient);

            var result = await downloader.DownloadSpotSymbolsKlinesAsync();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
