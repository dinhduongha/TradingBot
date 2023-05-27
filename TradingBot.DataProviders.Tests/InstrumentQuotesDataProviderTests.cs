using Bybit.Net.Clients;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.CryptoExchanges.ByBit;
using TradingBot.TradeAdapters;

namespace TradingBot.DataProviders.Tests
{
    public class InstrumentQuotesDataProviderTests
    {
        private readonly ITradeAdapter _adapter;
        private readonly IInstrumentsDataProvider _instrumentsDataProvider;

        public InstrumentQuotesDataProviderTests(BybitClient httpClient, ByBitConverter converter)
        {
            _adapter = new ByBitTradeAdapter(httpClient, converter);
            _instrumentsDataProvider = new InstrumentsDataProvider(_adapter);
        }

        [Fact]
        public async Task Provide_ReturnNotNullAndNotEmptyResult()
        {
            var result = new List<KeyValuePair<Instrument, IQuote>>();

            var provider = new InstrumentQuotesDataProvider(new QuotesDataProvider(DateTime.UtcNow.AddDays(-7),
                DateTime.UtcNow, Interval.OneDay, _adapter), _instrumentsDataProvider);

            await foreach (var item in provider.Provide())
            {
                result.Add(new KeyValuePair<Instrument, IQuote>(item.Key, item.Value));
            }

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
