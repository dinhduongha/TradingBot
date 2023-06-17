using Bybit.Net.Clients;
using Bybit.Net.Enums;
using Bybit.Net.Objects;
using Skender.Stock.Indicators;
using System.Net.NetworkInformation;
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

        public async Task<Instrument> GetInstrumentAsync(Symbol symbol)
        {
            var ticker = _converter.Ticker.Convert(symbol);

            var response = await _client.V5Api.ExchangeData.GetSpotSymbolsAsync(ticker);
            var instrument = response?.Data?.List?.SingleOrDefault();

            if (instrument != null) return _converter.Instrument.Convert(instrument);
            else throw new NotSupportedException(ticker);
        }

        public async Task<IEnumerable<Instrument>> GetInstrumentsAsync()
        {
            var response = await _client.V5Api.ExchangeData.GetSpotSymbolsAsync();

            return response?.Data?.List?.Select(_converter.Instrument.Convert) ?? Enumerable.Empty<Instrument>();
        }

        public async Task<IEnumerable<IQuote>> GetHistoricalQuotesAsync(Symbol symbol, Interval interval, 
            DateTime from, DateTime to)
        {
            var ticker = _converter.Ticker.Convert(symbol);

            var response = await _client.V5Api.ExchangeData.GetKlinesAsync(Category.Spot, 
                ticker, _converter.Interval.Convert(interval), from, to);
            var quotes = response?.Data;

            return quotes?.List?.Select(_converter.Quote.Convert) ?? Enumerable.Empty<Quote>();
        }

        public async Task<long> GetPingAsync()
        {
            var uri = new Uri(BybitClientOptions.Default.SpotApiOptions.BaseAddress);

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
            var callResult = await _client.V5Api.ExchangeData.GetServerTimeAsync();

            return callResult.Data.TimeSecond.ToUniversalTime();
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
