using TradingBot.Core.Domain;
using TradingBot.Quik;
using TradingBot.TradeAdapters;

namespace TradingBot.DataProviders.Tests
{
    public class InstrumentsDataProviderTests
    {
        private readonly IInstrumentsDataProvider _provider;

        public InstrumentsDataProviderTests(QuikSharp.Quik quik, QuikConverter converter)
        {
            _provider = new InstrumentsDataProvider(new QuikTradeAdapter(quik, converter));
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
