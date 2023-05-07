using Binance.Net.Clients;
using Binance.Net.Objects.Models.Spot;
using Skender.Stock.Indicators;
using TradingBot.Core.Abstracts;
using TradingBot.Core.Domain;

namespace TradingBot.TradeAdapters
{
    public class BinanceTradeAdapter : ITradeAdapter, IFactory<BinanceSymbol, StockTicker>
    {
        private readonly BinanceClient _client;

        public BinanceTradeAdapter(BinanceClient client)
        {
            _client = client;
        }

        public StockTicker Create(BinanceSymbol input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new StockTicker(input.Name, $"BINANCE {input.BaseAsset}/{input.QuoteAsset}",
                input.BaseAsset, StockExchange.Binance, InstrumentType.Spot, new Currency(input.QuoteAsset),
                    new LotFilter(input.LotSizeFilter?.StepSize), new PriceFilter(input?.PriceFilter?.TickSize));
        }

        public async Task<StockTicker> GetTicker(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));

            var response = await _client.SpotApi.ExchangeData.GetExchangeInfoAsync(code);
            var ticker = response?.Data?.Symbols?.SingleOrDefault();

            return ticker != null ? Create(ticker) : throw new NotSupportedException(code);
        }

        public async Task<IEnumerable<StockTicker>> GetTickers()
        {
            var response = await _client.SpotApi.ExchangeData.GetExchangeInfoAsync();

            return response?.Data?.Symbols?.Select(Create) ?? Enumerable.Empty<StockTicker>();
        }

        public Task<IEnumerable<IQuote>> GetQuotes(string code, Interval interval, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
