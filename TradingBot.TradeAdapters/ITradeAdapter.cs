using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.TradeAdapters
{
    public interface ITradeAdapter
    {
        Task<Instrument> GetInstrument(Symbol symbol);

        Task<IEnumerable<Instrument>> GetInstruments();

        Task<IEnumerable<IQuote>> GetHistoricalQuotes(Symbol symbol, Interval interval, DateTime from, DateTime to);
    }
}
