using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.DataProviders
{
    public class InstrumentQuotesDataProvider : IInstrumentQuotesDataProvider
    {
        private readonly IQuotesDataProvider _quotesDataProvider;
        private readonly IInstrumentsDataProvider _instrumentsDataProvider;

        public InstrumentQuotesDataProvider(IQuotesDataProvider quotesDataProvider, 
            IInstrumentsDataProvider tickersDataProvider)
        {
            _quotesDataProvider = quotesDataProvider;
            _instrumentsDataProvider = tickersDataProvider;
        }

        public async IAsyncEnumerable<KeyValuePair<Instrument, IQuote>> Provide()
        {
            var tickers = await GetInstrumentsAsync();

            var tickersQuotes = await GetInstrumentsQuotesAsync(tickers);

            tickersQuotes = tickersQuotes.OrderBy(pair => pair.Value.Date).ToList();

            foreach (var tickerQuote in tickersQuotes)
            {
                yield return tickerQuote;
            }
        }

        private async Task<IEnumerable<Instrument>> GetInstrumentsAsync()
        {
            var result = new List<Instrument>();

            await foreach (var ticker in _instrumentsDataProvider.Provide())
            {
                result.Add(ticker);
            }

            return result;
        }

        private async Task<IEnumerable<KeyValuePair<Instrument, IQuote>>> GetInstrumentsQuotesAsync(
            IEnumerable<Instrument> tickers)
        {
            var result = new List<KeyValuePair<Instrument, IQuote>>();

            var tasksCount = 25;

            for (var i = 0; i < tickers.Count() / tasksCount + 1; i++)
            {
                var tasks = new List<Task>();

                var tickersList = tickers.Skip(i * tasksCount).Take(tasksCount);

                foreach (var ticker in tickersList)
                {
                    var task = Task.Run(async () =>
                    {
                        await foreach (var quote in _quotesDataProvider.Provide(ticker.Symbol))
                        {
                            result.Add(new KeyValuePair<Instrument, IQuote>(ticker, quote));
                        }
                    });

                    tasks.Add(task);
                }

                await Task.WhenAll(tasks);
            }

            return result;
        }
    }
}
