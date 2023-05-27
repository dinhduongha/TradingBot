using Bybit.Net.Clients;
using TradingBot.Core.Domain;
using TradingBot.CryptoExchanges.ByBit;
using TradingBot.TradeAdapters;

namespace TradingBot.DataProviders.Tests
{
    public class InstrumentsDataProviderTests
    {
        private readonly IInstrumentsDataProvider _provider;

        public InstrumentsDataProviderTests(BybitClient httpClient, ByBitConverter converter)
        {
            _provider = new InstrumentsDataProvider(new ByBitTradeAdapter(httpClient, converter));
        }

        [Fact]
        public async Task Provide_ReturnNotNullAndNotEmptyResult()
        {
            var tickers = new List<Instrument>();

            await foreach (var ticker in _provider.Provide())
            {
                tickers.Add(ticker);
            }

            Assert.NotNull(tickers);
            Assert.NotEmpty(tickers);
        }
    }
}
