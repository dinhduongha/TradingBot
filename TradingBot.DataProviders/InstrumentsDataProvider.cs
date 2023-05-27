using TradingBot.Core.Domain;
using TradingBot.TradeAdapters;

namespace TradingBot.DataProviders
{
    public class InstrumentsDataProvider : IInstrumentsDataProvider
    {
        private readonly ITradeAdapter _adapter;

        public InstrumentsDataProvider(ITradeAdapter adapter)
        {
            _adapter = adapter;
        }

        public async IAsyncEnumerable<Instrument> Provide()
        {
            var tickers = await _adapter.GetInstruments();

            foreach (var ticker in tickers)
            {
                yield return ticker;
            }
        }
    }
}
