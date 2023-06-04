using QuikSharp;
using Skender.Stock.Indicators;
using System.Globalization;
using TradingBot.Core.Domain;
using TradingBot.Quik;

namespace TradingBot.TradeAdapters
{
    public class QuikTradeAdapter : ITradeAdapter
    {
        private readonly string[] _supportedClasses = new string[2] { "TQBR", "SPBXM" };

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

            var classCode = await _quik.Class.GetSecurityClass(string.Join(",", _supportedClasses), ticker);
            var instrument = await _quik.Class.GetSecurityInfo(classCode, ticker);

            if (instrument != null) return _converter.Instrument.Convert(instrument);
            else throw new NotSupportedException(ticker);
        }

        public async Task<IEnumerable<Instrument>> GetInstruments()
        {
            var codes = await _quik.Class.GetClassSecurities(string.Join(",", _supportedClasses));

            var tickers = new List<Instrument>();

            foreach (var code in codes)
            {
                tickers.Add(await GetInstrument(new Symbol(code, InstrumentType.Stock)));
            }

            return tickers;
        }

        public async Task<IEnumerable<IQuote>> GetHistoricalQuotes(Symbol symbol, Interval interval, 
            DateTime from, DateTime to)
        {
            var ticker = _converter.Ticker.Convert(symbol);

            var classCode = await _quik.Class.GetSecurityClass(string.Join(",", _supportedClasses), ticker);
            var candles = await _quik.Candles.GetAllCandles(classCode, ticker, _converter.Interval.Convert(interval));

            return candles
                .Where(candle => _converter.DateTime.Convert(candle.Datetime) >= from &&
                    _converter.DateTime.Convert(candle.Datetime) <= to)
                .Select(_converter.Quote.Convert);
        }

        public async Task<long> GetPingAsync()
        {
            var stringPing = await _quik.Service.GetInfoParam(InfoParams.LASTPINGDURATION);

            return Convert.ToInt64(double.Parse(stringPing, CultureInfo.InvariantCulture) * 1000L);
        }

        public async Task SubscribeToPingChangedAsync(Action<long> onPingChangedHandler, 
            CancellationToken token = default)
        {
            var task = new Task(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    var ping = await GetPingAsync();

                    onPingChangedHandler?.Invoke(ping);

                    await Task.Delay(1000);
                }
            }, token);

            task.Start();

            await Task.CompletedTask;
        }

        public async Task<DateTime> GetServerTimeAsync()
        {
            var timeString = await _quik.Service.GetInfoParam(InfoParams.SERVERTIME);

            return DateTime.Parse(timeString).ToUniversalTime();
        }

        public async Task SubscribeToServerTimeChangedAsync(Action<DateTime> onServerTimeChangedHandler, 
            CancellationToken token = default)
        {
            var task = new Task(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    var time = await GetServerTimeAsync();

                    onServerTimeChangedHandler?.Invoke(time);

                    await Task.Delay(1000);
                }
            }, token);

            task.Start();

            await Task.CompletedTask;
        }
    }
}
