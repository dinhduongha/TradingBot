using TradingBot.Core.Domain;
using TradingBot.DataProviders;
using TradingBot.Quik;
using TradingBot.TechnicalAnalyze.Strategies;
using TradingBot.TradeAdapters;

namespace TradingBot.TradingStrategiesTester.Tests
{
    public class TradingStrategiesTesterTests
    {
        private readonly ITradeAdapter _adapter;
        private readonly IInstrumentsDataProvider _instrumentsDataProvider;

        public TradingStrategiesTesterTests(QuikSharp.Quik quik, QuikConverter converter) 
        {
            _adapter = new QuikTradeAdapter(quik, converter);
            _instrumentsDataProvider = new InstrumentsDataProvider(_adapter);
        }

        [Fact]
        public async Task TestAsync()
        {
            var strategy = new Lev4andTradingStrategy();

            var poorTrader = new SimulationTrader(new Wallets() { { "SUR", new Wallet("SUR", 5000) } }, strategy);
            var middleTrader = new SimulationTrader(new Wallets() { { "SUR", new Wallet("SUR", 50000) } }, strategy);
            var richTrader = new SimulationTrader(new Wallets() { { "SUR", new Wallet("SUR", 500000) } }, strategy);

            var traders = new List<ISimulationTrader>() { poorTrader, middleTrader, richTrader };

            var quotesDataProvider = new QuotesDataProvider(DateTime.UtcNow.AddYears(-2), DateTime.UtcNow, 
                Interval.OneDay, _adapter);

            var instrumentsQuotesDataProvider = new InstrumentQuotesDataProvider(quotesDataProvider, _instrumentsDataProvider);

            var tester = new TradingStrategiesTester(traders, instrumentsQuotesDataProvider);

            tester.Start();

            while (tester.IsRunning)
            {
                await Task.Delay(100);
            }

            Assert.NotNull(tester.InstrumentQuotes);
            Assert.NotEmpty(tester.InstrumentQuotes);
        }
    }
}
