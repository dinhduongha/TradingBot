using Skender.Stock.Indicators;
using TradingBot.Core.Domain;

namespace TradingBot.TradeAdapters
{
    public interface ITradeAdapter
    {
        Task<StockTicker> GetTicker(string code);

        Task<IEnumerable<StockTicker>> GetTickers();

        Task<IEnumerable<IQuote>> GetHistoricalQuotes(string code, Interval interval, DateTime from, DateTime to);
    }
}
