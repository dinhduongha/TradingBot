using Bybit.Net.Clients;
using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using TradingBot.Core.Actor;

namespace TradingBot.Downloader
{
    public class DownloaderSpotKlinesActor : AbstractActor<BybitSpotSymbol>
    {
        private readonly DateTime _from;
        private readonly DateTime _to;

        private readonly KlineInterval _interval;

        private readonly BybitClient _httpClient;
        private readonly DownloaderSpotKlinesEventBus _eventBus;

        public override int ThreadCount => 20;

        public DownloaderSpotKlinesActor(DateTime from, DateTime to, KlineInterval interval, BybitClient httpClient,
            DownloaderSpotKlinesEventBus eventBus)
        {
            _to = to;
            _from = from;
            _interval = interval;
            _eventBus = eventBus;
            _httpClient = httpClient;
        }

        public override Task HandleError(BybitSpotSymbol message, Exception ex)
        {
            throw new NotImplementedException();
        }

        public override async Task HandleMessage(BybitSpotSymbol message)
        {
            var maxValues = 200;
            var differenceTime = _to - _from;
            var countIterations = differenceTime.TotalSeconds / (int)_interval / maxValues;

            var klines = new List<BybitKline>();

            for (var i = 0; i < countIterations; i++)
            {
                var klinesResponse = await _httpClient.V5Api.ExchangeData.GetKlinesAsync(Category.Spot, message.Name,
                    _interval, _from <= _from.AddSeconds(-((i + 1) * (int)_interval * maxValues))
                        ? _from.AddSeconds(-((i + 1) * (int)_interval * maxValues)) 
                        : _from,
                    _to.AddSeconds(-(i * (int)_interval * maxValues)));

                klines.AddRange(klinesResponse.Data.List);
            }

            _eventBus.RaiseOnDownloadedKlines(message, klines);
        }
    }
}
