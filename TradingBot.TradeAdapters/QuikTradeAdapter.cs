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

        public async Task<Instrument> GetInstrumentAsync(Symbol symbol)
        {
            var ticker = _converter.Ticker.Convert(symbol);

            var classCode = await _quik.Class.GetSecurityClass(string.Join(",", _supportedClasses), ticker);
            var instrument = await _quik.Class.GetSecurityInfo(classCode, ticker);

            if (instrument != null) return _converter.Instrument.Convert(instrument);
            else throw new NotSupportedException(ticker);
        }

        public async Task<IEnumerable<Instrument>> GetInstrumentsAsync()
        {
            var codes = await _quik.Class.GetClassSecurities(string.Join(",", _supportedClasses));

            var tickers = new List<Instrument>();

            foreach (var code in codes)
            {
                tickers.Add(await GetInstrumentAsync(new Symbol(code, InstrumentType.Stock)));
            }

            return tickers;
        }

        public async Task<IEnumerable<IQuote>> GetHistoricalQuotesAsync(Symbol symbol, Interval interval, 
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

        public async Task<OrderBook> GetOrderBookAsync(Symbol symbol)
        {
            if (symbol == null) throw new ArgumentNullException(nameof(symbol));

            var ticker = _converter.Ticker.Convert(symbol);

            var classCode = await _quik.Class.GetSecurityClass(string.Join(",", _supportedClasses), ticker);
            var orderBook = await _quik.OrderBook.GetQuoteLevel2(classCode, ticker);

            return _converter.OrderBook.Convert(orderBook);
        }

        public async Task SubscribeToOrderBookChangedAsync(Symbol symbol, Action<Symbol, OrderBook> onOrderBookChangedHandler, 
            CancellationToken token = default)
        {
            if (symbol == null) throw new ArgumentNullException(nameof(symbol));

            var onQuoteHandler = new QuoteHandler(orderBook =>
            {
                onOrderBookChangedHandler.Invoke(symbol, _converter.OrderBook.Convert(orderBook));
            });

            var task = new Task(async () =>
            {
                _quik.Events.OnQuote += onQuoteHandler;

                while (!token.IsCancellationRequested)
                {
                    await Task.Delay(1000);
                }

                _quik.Events.OnQuote -= onQuoteHandler;
            }, token);

            task.Start();

            await Task.CompletedTask;
        }

        public async Task SubscribeToOrderBookChangedAsync(Action<Symbol, OrderBook> onOrderBookChangedHandler, 
            CancellationToken token = default)
        {
            var task = new Task(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    await Task.Delay(1000);
                }
            }, token);

            task.Start();

            await Task.CompletedTask;
        }
    }
}
