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

        public IDictionary<Instrument, IChart> InstrumentQuotes { get; }

        public IInstrumentQuotesDataProvider InstrumentQuotesDataProvider { get; }

        public TradingStrategiesTester(IEnumerable<ISimulationTrader> traders, 
            IInstrumentQuotesDataProvider instrumentQuotesDataProvider)
        {
            if (traders == null || traders.Count() == 0) throw new ArgumentNullException(nameof(traders));

            _isRunning = false;

            Traders = traders;
            InstrumentQuotes = new Dictionary<Instrument, IChart>();
            InstrumentQuotesDataProvider = instrumentQuotesDataProvider;

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
            await foreach (var instrumentQuote in ProvideInstrumentQuoteAsync())
            {
                MapInstrumentQuote(instrumentQuote);

                ExecuteOrders();

                PlaceOrders();
            }
        }

        private async IAsyncEnumerable<KeyValuePair<Instrument, IQuote>> ProvideInstrumentQuoteAsync()
        {
            await foreach (var instrumentQuote in InstrumentQuotesDataProvider.Provide())
            {
                yield return instrumentQuote;
            }
        }

        private void MapInstrumentQuote(KeyValuePair<Instrument, IQuote> instrumentQuote)
        {
            if (InstrumentQuotes.ContainsKey(instrumentQuote.Key)) InstrumentQuotes[instrumentQuote.Key].Add(instrumentQuote.Value);
            else InstrumentQuotes.Add(instrumentQuote.Key, new Chart(new List<IQuote>() { instrumentQuote.Value }));
        }

        private void ExecuteOrders()
        {

        }

        private void PlaceOrders()
        {

        }
    }
}
