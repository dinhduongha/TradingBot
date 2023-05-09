using Skender.Stock.Indicators;
using TradingBot.Core.Abstracts;

namespace TradingBot.DataProviders
{
    public interface IQuotesDataProvider : IProviderLazy<Dictionary<string, IQuote>>
    {

    }
}
