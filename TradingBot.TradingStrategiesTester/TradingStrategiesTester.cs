using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.Core.Domain.Chart;
using TradingBot.DataProviders;

namespace TradingBot.TradingStrategiesTester
{
    public class TradingStrategiesTester : ITradingStrategiesTester
    {
        private bool _isRunning;

        public bool IsRunning => _isRunning;

        public IEnumerable<ISimulationTrader> Traders { get; }

        public IDictionary<StockTicker, IChart> TickersQuotes { get; }

        public ITickerQuotesDataProvider TickerQuotesDataProvider { get; }

        public TradingStrategiesTester(IEnumerable<ISimulationTrader> traders, 
            ITickerQuotesDataProvider tickerQuotesDataProvider)
        {
            if (traders == null || traders.Count() == 0) throw new ArgumentNullException(nameof(traders));

            _isRunning = false;

            Traders = traders;
            TickersQuotes = new Dictionary<StockTicker, IChart>();
            TickerQuotesDataProvider = tickerQuotesDataProvider;

            Task.Run(async () =>
            {
                while (true)
                {
                    while (_isRunning)
                    {
                        await TestAsync();

                        Stop();
                    }
                }
            });
        }

        public void Start()
        {
            if (!_isRunning)
            {
                _isRunning = true;
            }
        }

        public void Stop()
        {
            if (_isRunning)
            {
                _isRunning = false;
            }
        }

        public async Task TestAsync()
        {
            await foreach (var tickerQuote in ProvideTickerQuoteAsync())
            {
                MapTickerQuote(tickerQuote);

                ExecuteOrders();

                PlaceOrders();
            }
        }

        private async IAsyncEnumerable<KeyValuePair<StockTicker, IQuote>> ProvideTickerQuoteAsync()
        {
            await foreach (var tickerQuote in TickerQuotesDataProvider.Provide())
            {
                yield return tickerQuote;
            }
        }

        private void MapTickerQuote(KeyValuePair<StockTicker, IQuote> tickerQuote)
        {
            if (TickersQuotes.ContainsKey(tickerQuote.Key)) TickersQuotes[tickerQuote.Key].Add(tickerQuote.Value);
            else TickersQuotes.Add(tickerQuote.Key, new Chart(new List<IQuote>() { tickerQuote.Value }));
        }

        private void ExecuteOrders()
        {

        }

        private void PlaceOrders()
        {

        }
    }
}
