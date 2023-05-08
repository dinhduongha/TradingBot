using Skender.Stock.Indicators;
using TradingBot.Core.Abstracts;
using TradingBot.Core.Domain;

namespace TradingBot.QuotesDataProvider
{
    public interface IQuotesDataProvider : IProvider<Dictionary<StockTicker, IEnumerable<IQuote>>>
    {

    }
}
