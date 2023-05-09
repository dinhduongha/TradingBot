using Bybit.Net.Clients;
using TradingBot.Core.Domain;
using TradingBot.DataProviders;
using TradingBot.TradeAdapters;

namespace TradingBot.ExchangeSimulator.Tests
{
    public class ExchangeSimulatorTests
    {
        private readonly ITradeAdapter _adapter;

        public ExchangeSimulatorTests(BybitClient client)
        {
            _adapter = new ByBitTradeAdapter(client);
        }

        [Fact]
        public async Task StartAsync()
        {
            var to = DateTime.UtcNow;
            var from = DateTime.UtcNow.AddDays(-3);

            var interval = Interval.OneMinute;

            var tickersDataProvider = new TickersDataProvider(_adapter);
            var quotesDataProvider = new QuotesDataProvider(from, to, interval, _adapter);

            var simulator = new ExchangeSimulator(from, to, interval, quotesDataProvider, tickersDataProvider);

            simulator.Start();

            while (simulator.IsRunning)
            {
                await Task.Delay(100);
            }

            Assert.NotNull(simulator.Quotes);
            Assert.NotEmpty(simulator.Quotes);
        }
    }
}
