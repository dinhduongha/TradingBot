using Bybit.Net.Clients;
using Bybit.Net.Enums;
using TradingBot.Core.Domain;

namespace TradingBot.TechnicalAnalyze.Core.Tests
{
    public class ChartTests
    {
        private readonly BybitClient _httpClient;

        public ChartTests(BybitClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Fact]
        public async Task ChartConstructor_WithCandles_ReturnObject()
        {
            var response = await _httpClient.V5Api.ExchangeData.GetKlinesAsync(Category.Spot, "ETHUSDT",
                KlineInterval.OneMinute, DateTime.UtcNow.AddDays(-3), DateTime.UtcNow, 1000);

            var candles = response.Data.List.Select(value => new CustomQuote(value.LowPrice, value.OpenPrice, 
                value.HighPrice, value.ClosePrice, value.Volume, value.StartTime)) ?? new List<CustomQuote>();

            var chart = new Chart(candles);

            Assert.NotNull(chart);

            Assert.NotNull(chart.Quotes);
            Assert.NotEmpty(chart.Quotes);

            Assert.NotNull(chart.Indicators);
            Assert.NotEmpty(chart.Indicators);
        }
    }
}
