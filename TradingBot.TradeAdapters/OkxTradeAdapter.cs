using Okex.Net;
using Okex.Net.Enums;
using Okex.Net.Objects.Public;
using Skender.Stock.Indicators;
using TradingBot.Core.Abstracts;
using TradingBot.Core.Domain;

namespace TradingBot.TradeAdapters
{
    public class OkxTradeAdapter : ITradeAdapter, IFactory<OkexInstrument, StockTicker>
    {
        private readonly OkexClient _client;

        public OkxTradeAdapter(OkexClient client)
        {
            _client = client;
        }

        public StockTicker Create(OkexInstrument input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new StockTicker(input.Instrument, $"OKX {input.BaseCurrency}/{input.QuoteCurrency}",
                input.BaseCurrency, StockExchange.Okx, InstrumentType.Spot, new Currency(input.QuoteCurrency),
                    new LotFilter(input.LotSize), new PriceFilter(input.MinimumOrderSize));
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var response = await _client.GetInstrumentsAsync(OkexInstrumentType.Spot, instrumentId: code);
            var ticker = response?.Data?.SingleOrDefault();

            return ticker != null ? Create(ticker) : throw new NotSupportedException(code);
        }

        public async Task<IEnumerable<StockTicker>> GetTickers()
        {
            var response = await _client.GetInstrumentsAsync(OkexInstrumentType.Spot);

            return response?.Data?.Select(Create) ?? Enumerable.Empty<StockTicker>();
        }

        public Task<IEnumerable<IQuote>> GetQuotes(string code, Interval interval, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
