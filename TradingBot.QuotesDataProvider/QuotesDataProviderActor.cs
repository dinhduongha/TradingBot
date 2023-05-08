using Skender.Stock.Indicators;
using TradingBot.Core.Actor;
using TradingBot.Core.Domain;
using TradingBot.TradeAdapters;

namespace TradingBot.QuotesDataProvider
{
    internal class QuotesDataProviderActor : AbstractActor<StockTicker>
    {
        private readonly DateTime _to;
        private readonly DateTime _from;
        private readonly Interval _interval;
        private readonly ITradeAdapter _adapter;
        private readonly QuotesDataProviderEventBus _eventBus;

        public override int ThreadCount => 20;

        public QuotesDataProviderActor(DateTime from, DateTime to, Interval interval, ITradeAdapter adapter,
            QuotesDataProviderEventBus eventBus)
        {
            _to = to;
            _from = from;
            _adapter = adapter;
            _interval = interval;
            _eventBus = eventBus;
        }

        public override Task HandleError(StockTicker message, Exception ex)
        {
            throw new NotImplementedException();
        }

        public override async Task HandleMessage(StockTicker message)
        {
            var historicalQuotes = new List<IQuote>();
            var to = _to;

            while (to >= _from)
            {
                var quotes = await _adapter.GetHistoricalQuotes(message.Code, _interval, _from, to);

                if (quotes != null && quotes.Count() > 0)
                {
                    historicalQuotes.AddRange(quotes);

                    to = quotes.Min(quote => quote.Date).AddSeconds(-(int)_interval);
                }
                else break;
            }

            _eventBus.RaiseOnDownloadedQuotes(message, historicalQuotes);
        }
    }
}
