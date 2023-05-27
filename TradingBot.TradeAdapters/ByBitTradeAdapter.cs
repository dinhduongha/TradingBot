using Bybit.Net.Clients;
using Bybit.Net.Enums;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.CryptoExchanges.ByBit;

namespace TradingBot.TradeAdapters
{
    public class ByBitTradeAdapter : ITradeAdapter
    {
        private readonly BybitClient _client;
        private readonly ByBitConverter _converter;

        public ByBitTradeAdapter(BybitClient client, ByBitConverter converter)
        {
            _client = client;
            _converter = converter;
        }

        public async Task<Instrument> GetInstrument(Symbol symbol)
        {
            var ticker = _converter.Ticker.Convert(symbol);
            var response = await _client.V5Api.ExchangeData.GetSpotSymbolsAsync(ticker);
            var instrument = response?.Data?.List?.SingleOrDefault();

            if (instrument != null) return _converter.Instrument.Convert(instrument);
            else throw new NotSupportedException(ticker);
        }

        public async Task<IEnumerable<Instrument>> GetInstruments()
        {
            var response = await _client.V5Api.ExchangeData.GetSpotSymbolsAsync();

            return response?.Data?.List?.Select(_converter.Instrument.Convert) ?? Enumerable.Empty<Instrument>();
        }

        public async Task<IEnumerable<IQuote>> GetHistoricalQuotes(Symbol symbol, Interval interval, 
            DateTime from, DateTime to)
        {
            var ticker = _converter.Ticker.Convert(symbol);
            var response = await _client.V5Api.ExchangeData.GetKlinesAsync(Category.Spot, 
                ticker, _converter.Interval.Convert(interval), from, to);
            var quotes = response?.Data;

            return quotes?.List?.Select(_converter.Quote.Convert) ?? Enumerable.Empty<Quote>();
        }
    }
}
