using Bybit.Net.Clients;
using TradingBot.Core.Domain;
using TradingBot.CryptoExchanges.ByBit;
using TradingBot.DataProviders;
using TradingBot.TechnicalAnalyze.Strategies;
using TradingBot.TradeAdapters;

namespace TradingBot.TradingStrategiesTester.Tests
{
    public class TradingStrategiesTesterTests
    {
        private readonly ITradeAdapter _adapter;
        private readonly IInstrumentsDataProvider _instrumentsDataProvider;

        public TradingStrategiesTesterTests(BybitClient httpClient, ByBitConverter converter) 
        {
            _adapter = new ByBitTradeAdapter(httpClient, converter);
            _instrumentsDataProvider = new InstrumentsDataProvider(_adapter);
        }

        [Fact]
        public async Task TestAsync()
        {
            var strategy = new Lev4andTradingStrategy();

            var poorTrader = new SimulationTrader(new Wallets() { { "USDT", new Wallet("USDT", 50) } }, strategy);
            var middleTrader = new SimulationTrader(new Wallets() { { "USDT", new Wallet("USDT", 500) } }, strategy);
            var richTrader = new SimulationTrader(new Wallets() { { "USDT", new Wallet("USDT", 5000) } }, strategy);

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
