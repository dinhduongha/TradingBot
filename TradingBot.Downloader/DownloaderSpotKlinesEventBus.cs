using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;

namespace TradingBot.Downloader
{
    public class DownloaderSpotKlinesEventBus
    {
        public event Action<BybitSpotSymbol, IEnumerable<BybitKline>> OnDownloadedKlines;

        public void RaiseOnDownloadedKlines(BybitSpotSymbol symbol, IEnumerable<BybitKline> klines)
        {
            OnDownloadedKlines?.Invoke(symbol, klines);
        }

        public void Subscribe(Action<BybitSpotSymbol, IEnumerable<BybitKline>> handler)
        {
            OnDownloadedKlines += handler;
        }

        public void Unsubscribe(Action<BybitSpotSymbol, IEnumerable<BybitKline>> handler)
        {
            OnDownloadedKlines -= handler;
        }
    }
}
