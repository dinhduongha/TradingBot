using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.Core.Domain.Chart;
using TradingBot.DataProviders;

namespace TradingBot.ExchangeSimulator
{
    public class ExchangeSimulator : IExchangeSimulator
    {
        private readonly IQuotesDataProvider _quotesDataProvider;
        private readonly ITickersDataProvider _tickersDataProvider;

        private bool _isRunning;
        private DateTime _time;
        private Interval _interval;
        private Dictionary<string, StockTicker> _tickers;
        private Dictionary<string, IChart> _quotes;

        public bool IsRunning => _isRunning;

        public DateTime To { get; }

        public DateTime From { get; }

        public DateTime Time => _time;

        public Dictionary<string, StockTicker> Tickers => _tickers;

        public Dictionary<string, IChart> Quotes => _quotes;

        public ExchangeSimulator(DateTime from, DateTime to, Interval interval, IQuotesDataProvider quotesDataProvider, 
            ITickersDataProvider tickersDataProvider)
        {
            if (from > to) throw new ArgumentOutOfRangeException(nameof(from));
            if (to < from) throw new ArgumentOutOfRangeException(nameof(to));

            _quotesDataProvider = quotesDataProvider;
            _tickersDataProvider = tickersDataProvider;

            _time = from;
            _isRunning = false;
            _interval = interval;
            _tickers = new Dictionary<string, StockTicker>();
            _quotes = new Dictionary<string, IChart>();

            To = to;
            From = from;

            Task.Run(async () =>
            {
                while (true)
                {
                    while (_isRunning)
                    {
                        await InitializeAsync();
                        await SimulateAsync();

                        Stop();
                    }
                }
            });
        }

        public void Start()
        {
            _isRunning = true;
        }

        public void Stop()
        {
            _isRunning = false;
        }

        private async Task InitializeAsync()
        {
            _time = From;
            _quotes = new Dictionary<string, IChart>();
            _tickers = await _tickersDataProvider.ProvideAsync();
        }

        private async Task SimulateAsync()
        {
            await foreach (var tickersQuote in _quotesDataProvider.ProvideLazyAsync())
            {
                SetTickerQuotes(tickersQuote);



                _time = _time.AddSeconds((int)_interval);
            }
        }

        private void SetTickerQuotes(Dictionary<string, IQuote> tickersQuote)
        {
            foreach (var tickerQuote in tickersQuote)
            {
                SetTickerQuote(tickerQuote);
            }
        }

        private void SetTickerQuote(KeyValuePair<string, IQuote> tickerQuote)
        {
            if (_quotes.ContainsKey(tickerQuote.Key)) _quotes[tickerQuote.Key].Add(tickerQuote.Value);
            else _quotes.Add(tickerQuote.Key, new Chart(new List<IQuote>() { tickerQuote.Value }));
        }
    }
}
