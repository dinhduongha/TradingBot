using Bybit.Net.Clients;
using Bybit.Net.Objects.Models.V5;
using Skender.Stock.Indicators;
using TradingBot.Core.Abstracts;
using TradingBot.Core.Domain;

namespace TradingBot.TradeAdapters
{
    public class ByBitTradeAdapter : ITradeAdapter, IFactory<BybitSpotSymbol, StockTicker>
    {
        private readonly BybitClient _client;

        public ByBitTradeAdapter(BybitClient client)
        {
            _client = client;
        }

        public StockTicker Create(BybitSpotSymbol input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new StockTicker(input.Name, $"BYBIT {input.BaseAsset}/{input.QuoteAsset}",
                input.BaseAsset, StockExchange.ByBit, InstrumentType.Spot, new Currency(input.QuoteAsset),
                    new LotFilter(input.LotSizeFilter?.BasePrecision), new PriceFilter(input?.PriceFilter?.TickSize));
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var response = await _client.V5Api.ExchangeData.GetSpotSymbolsAsync(code);
            var ticker = response?.Data?.List?.SingleOrDefault();

            return ticker != null ? Create(ticker) : throw new NotSupportedException(code);
        }

        public async Task<IEnumerable<StockTicker>> GetTickers()
        {
            var response = await _client.V5Api.ExchangeData.GetSpotSymbolsAsync();

            return response?.Data?.List?.Select(Create) ?? Enumerable.Empty<StockTicker>();
        }

        public Task<IEnumerable<IQuote>> GetQuotes(string code, Interval interval, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
