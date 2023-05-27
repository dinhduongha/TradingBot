using QuikSharp.DataStructures;
using Skender.Stock.Indicators;
using TradingBot.Core.Domain;
using TradingBot.Quik;

namespace TradingBot.TradeAdapters
{
    public class QuikTradeAdapter : ITradeAdapter
    {
        private readonly QuikSharp.Quik _quik;
        private readonly QuikConverter _converter;

        public QuikTradeAdapter(QuikSharp.Quik quik, QuikConverter converter)
        {
            _quik = quik;
            _converter = converter;
        }

        public async Task<Instrument> GetInstrument(Symbol symbol)
        {
            var ticker = _converter.Ticker.Convert(symbol);
            var instrument = await _quik.Class.GetSecurityInfo("TQBR", ticker);

            if (instrument != null) return _converter.Instrument.Convert(instrument);
            else throw new NotSupportedException(ticker);
        }

        public async Task<IEnumerable<Instrument>> GetInstruments()
        {
            var codes = await _quik.Class.GetClassSecurities("TQBR");

            var tickers = new List<Instrument>();

            foreach (var code in codes)
            {
                tickers.Add(await GetInstrument(new Symbol(code, InstrumentType.Stock, new Currency("SUR"))));
            }

            return tickers;
        }

        public async Task<IEnumerable<IQuote>> GetHistoricalQuotes(Symbol symbol, Interval interval, 
            DateTime from, DateTime to)
        {
            var ticker = _converter.Ticker.Convert(symbol);
            var candles = await _quik.Candles.GetAllCandles("TQBR", ticker, _converter.Interval.Convert(interval));

            return candles
                .Where(candle => _converter.DateTime.Convert(candle.Datetime) >= from &&
                    _converter.DateTime.Convert(candle.Datetime) <= to)
                .Select(_converter.Quote.Convert);
        }
    }
}
