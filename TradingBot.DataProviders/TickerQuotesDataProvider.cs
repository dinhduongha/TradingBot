using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.DataProviders
{
    public class TickerQuotesDataProvider : ITickerQuotesDataProvider
    {
        private readonly IQuotesDataProvider _quotesDataProvider;
        private readonly ITickersDataProvider _tickersDataProvider;

        public TickerQuotesDataProvider(IQuotesDataProvider quotesDataProvider, ITickersDataProvider tickersDataProvider)
        {
            _quotesDataProvider = quotesDataProvider;
            _tickersDataProvider = tickersDataProvider;
        }

        public async IAsyncEnumerable<KeyValuePair<StockTicker, IQuote>> Provide()
        {
            var tickers = await GetTickersAsync();

            var tickersQuotes = await GetTickersQuotesAsync(tickers);

            tickersQuotes = tickersQuotes.OrderBy(pair => pair.Value.Date).ToList();

            foreach (var tickerQuote in tickersQuotes)
            {
                yield return tickerQuote;
            }
        }

        private async Task<IEnumerable<StockTicker>> GetTickersAsync()
        {
            var result = new List<StockTicker>();

            await foreach (var ticker in _tickersDataProvider.Provide())
            {
                result.Add(ticker);
            }

            return result;
        }

        private async Task<IEnumerable<KeyValuePair<StockTicker, IQuote>>> GetTickersQuotesAsync(
            IEnumerable<StockTicker> tickers)
        {
            var result = new List<KeyValuePair<StockTicker, IQuote>>();

            var tasksCount = 25;

            for (var i = 0; i < tickers.Count() / tasksCount + 1; i++)
            {
                var tasks = new List<Task>();

                var tickersList = tickers.Skip(i * tasksCount).Take(tasksCount);

                foreach (var ticker in tickersList)
                {
                    var task = Task.Run(async () =>
                    {
                        await foreach (var quote in _quotesDataProvider.Provide(ticker.Code))
                        {
                            result.Add(new KeyValuePair<StockTicker, IQuote>(ticker, quote));
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
