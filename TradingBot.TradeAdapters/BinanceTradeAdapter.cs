using Binance.Net.Clients;
using Binance.Net.Objects;
using Skender.Stock.Indicators;
using System.Net.NetworkInformation;
using TradingBot.Core.Domain;
using TradingBot.CryptoExchanges.Binance;

namespace TradingBot.TradeAdapters
{
    public class BinanceTradeAdapter : ITradeAdapter
    {
        private readonly BinanceClient _client;
        private readonly BinanceConverter _converter;

        public BinanceTradeAdapter(BinanceClient client, BinanceConverter converter)
        {
            _client = client;
            _converter = converter;
        }

        public async Task<Instrument> GetInstrument(Symbol symbol)
        {
            var ticker = _converter.Ticker.Convert(symbol);

            var response = await _client.SpotApi.ExchangeData.GetExchangeInfoAsync(ticker);
            var instrument = response?.Data?.Symbols?.SingleOrDefault();

            if (instrument != null) return _converter.Instrument.Convert(instrument);
            else throw new NotSupportedException(ticker);
        }

        public async Task<IEnumerable<Instrument>> GetInstruments()
        {
            var response = await _client.SpotApi.ExchangeData.GetExchangeInfoAsync();

            return response?.Data?.Symbols?.Select(_converter.Instrument.Convert) ?? Enumerable.Empty<Instrument>();
        }

        public async Task<IEnumerable<IQuote>> GetHistoricalQuotes(Symbol symbol, Interval interval, 
            DateTime from, DateTime to)
        {
            var ticker = _converter.Ticker.Convert(symbol);

            var response = await _client.SpotApi.ExchangeData.GetKlinesAsync(ticker, 
                _converter.Interval.Convert(interval), from, to);
            var quotes = response?.Data;

            return quotes?.Select(_converter.Quote.Convert) ?? Enumerable.Empty<Quote>();
        }

        public async Task<long> GetPingAsync()
        {
            var uri = new Uri(BinanceClientOptions.Default.SpotApiOptions.BaseAddress);

            var pingClient = new Ping();
            var pingResult = await pingClient.SendPingAsync(uri.Host);

            return pingResult.RoundtripTime;
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
            var callResult = await _client.SpotApi.ExchangeData.GetServerTimeAsync();

            return callResult.Data.ToUniversalTime();
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
