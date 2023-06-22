using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.TradeAdapters
{
    public interface ITradeAdapter
    {
        Task<Instrument> GetInstrumentAsync(Symbol symbol);

        Task<IEnumerable<Instrument>> GetInstrumentsAsync();

        Task<IEnumerable<IQuote>> GetHistoricalQuotesAsync(Symbol symbol, Interval interval, DateTime from, DateTime to);

        Task<long> GetPingAsync();

        Task SubscribeToPingChangedAsync(Action<long> onPingChangedHandler, CancellationToken token = default);

        Task<DateTime> GetServerTimeAsync();

        Task SubscribeToServerTimeChangedAsync(Action<DateTime> onServerTimeChangedHandler, CancellationToken token = default);
    }
}
