using Bybit.Net.Clients;
using TradingBot.Core.Domain;
using TradingBot.CryptoExchanges.ByBit;
using TradingBot.TradeAdapters;

namespace TradingBot.DataProviders.Tests
{
    public class TickersDataProviderTests
    {
        private readonly ITickersDataProvider _provider;

        public TickersDataProviderTests(BybitClient httpClient, ByBitConverter converter)
        {
            _provider = new TickersDataProvider(new ByBitTradeAdapter(httpClient, converter));
        }

        [Fact]
        public async Task Provide_ReturnNotNullAndNotEmptyResult()
        {
            var tickers = new List<StockTicker>();

            await foreach (var ticker in _provider.Provide())
            {
                tickers.Add(ticker);
            }

            Assert.NotNull(tickers);
            Assert.NotEmpty(tickers);
        }
    }
}
