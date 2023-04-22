using Bybit.Net.Clients;
using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;

namespace TradingBot.Downloader
{
    public class DownloaderSpotKlines : IDisposable
    {
        private readonly BybitClient _httpClient;

        private readonly DownloaderSpotKlinesActor _actor;
        private readonly DownloaderSpotKlinesEventBus _eventBus;

        private Dictionary<string, KeyValuePair<BybitSpotSymbol, IEnumerable<BybitKline>>> _spotSymbolsKlines;

        public DownloaderSpotKlines(DateTime from, DateTime to, KlineInterval interval, BybitClient httpClient)
        {
            _httpClient = httpClient;

            _eventBus = new DownloaderSpotKlinesEventBus();
            _eventBus.Subscribe(OnDownloadedKlines);

            _actor = new DownloaderSpotKlinesActor(from, to, interval, httpClient, _eventBus);
            _spotSymbolsKlines = new Dictionary<string, KeyValuePair<BybitSpotSymbol, IEnumerable<BybitKline>>>();
        }

        public async Task<Dictionary<string, KeyValuePair<BybitSpotSymbol, IEnumerable<BybitKline>>>> DownloadSpotSymbolsKlinesAsync()
        {
            _spotSymbolsKlines.Clear();

            var spotSymbols = await GetSpotSymbolsAsync();

            foreach (var spot in spotSymbols)
            {
                await _actor.SendAsync(spot);
            }

            while (_spotSymbolsKlines.Count < spotSymbols.Count())
            {
                await Task.Delay(100);
            }

            return _spotSymbolsKlines;
        }

        private async Task<IEnumerable<BybitSpotSymbol>> GetSpotSymbolsAsync()
        {
            var response = await _httpClient.V5Api.ExchangeData.GetSpotSymbolsAsync();

            return response.Data.List ?? new List<BybitSpotSymbol>();
        }

        private void OnDownloadedKlines(BybitSpotSymbol symbol, IEnumerable<BybitKline> klines)
        {
            _spotSymbolsKlines.Add(symbol.Name, new KeyValuePair<BybitSpotSymbol, IEnumerable<BybitKline>>(symbol, 
                klines));
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe(OnDownloadedKlines);
        }
    }
}
