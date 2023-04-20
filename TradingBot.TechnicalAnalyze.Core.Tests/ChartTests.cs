using TradingBot.Core.Domain;
using TradingBot.HttpClients.ByBit;
using TradingBot.HttpClients.ByBit.RequestModels;

namespace TradingBot.TechnicalAnalyze.Core.Tests
{
    public class ChartTests
    {
        private readonly MarketHttpClient _httpClient;

        public ChartTests(MarketHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Fact]
        public async Task ChartConstructor_WithCandles_ReturnObject()
        {
            var model = new GetKlineRequestModel(Category.Spot, "ETHUSDT", Interval.Day,
                DateTime.UtcNow.AddMonths(-6), DateTime.UtcNow);

            var response = await _httpClient.GetKlineAsync(model);

            var candles = response.Result?.Values.Select(value => new CustomQuote(value)) ?? new List<CustomQuote>();

            var chart = new Chart(candles);

            Assert.NotNull(chart);

            Assert.NotNull(chart.Quotes);
            Assert.NotEmpty(chart.Quotes);

            Assert.NotNull(chart.Indicators);
            Assert.NotEmpty(chart.Indicators);
        }
    }
}
