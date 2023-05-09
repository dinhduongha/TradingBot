using Bybit.Net.Clients;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.TradeAdapters;

namespace TradingBot.DataProviders.Tests
{
    public class QuotesDataProviderTests
    {
        private readonly ITradeAdapter _adapter;

        public QuotesDataProviderTests(BybitClient httpClient)
        {
            _adapter = new ByBitTradeAdapter(httpClient);
        }

        [Fact]
        public async Task ProvideTickersQuotesLazyAsync_WithParams_ReturnNotNullAndNotEmptyResult()
        {
            var result = new Dictionary<string, List<IQuote>>();

            var downloader = new QuotesDataProvider(DateTime.UtcNow.AddDays(-3), DateTime.UtcNow,
                Interval.FiveMinutes, _adapter);

            await foreach (var tickersQuotes in downloader.ProvideTickersQuotesLazyAsync()) 
            {
                foreach (var tickerQoutes in tickersQuotes)
                {
                    if (!result.ContainsKey(tickerQoutes.Key)) result.Add(tickerQoutes.Key, tickerQoutes.Value.ToList());
                    else result[tickerQoutes.Key].AddRange(tickerQoutes.Value);
                }
            }

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
