using Okex.Net;
using Okex.Net.Enums;
using Okex.Net.Helpers;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.CryptoExchanges.Okx;

namespace TradingBot.TradeAdapters
{
    public class OkxTradeAdapter : ITradeAdapter
    {
        private readonly OkexClient _client;
        private readonly OkxConverter _converter;

        public OkxTradeAdapter(OkexClient client, OkxConverter converter)
        {
            _client = client;
            _converter = converter;
        }

        public async Task<Instrument> GetInstrument(Symbol symbol)
        {
            var ticker = _converter.Ticker.Convert(symbol);
            var response = await _client.GetInstrumentsAsync(OkexInstrumentType.Spot, instrumentId: ticker);
            var instrument = response?.Data?.SingleOrDefault();

            if (instrument != null) return _converter.Instrument.Convert(instrument);
            else throw new NotSupportedException(ticker);
        }

        public async Task<IEnumerable<Instrument>> GetInstruments()
        {
            var response = await _client.GetInstrumentsAsync(OkexInstrumentType.Spot);

            return response?.Data?.Select(_converter.Instrument.Convert) ?? Enumerable.Empty<Instrument>();
        }

        public async Task<IEnumerable<IQuote>> GetHistoricalQuotes(Symbol symbol, Interval interval, 
            DateTime from, DateTime to)
        {
            var ticker = _converter.Ticker.Convert(symbol);
            var response = await _client.GetCandlesticksHistoryAsync(ticker, _converter.Interval.Convert(interval), 
                to.ToUnixTimeMilliSeconds(), from.ToUnixTimeMilliSeconds());

            return response?.Data?.Select(_converter.Quote.Convert) ?? Enumerable.Empty<Quote>();
        }
    }
}
