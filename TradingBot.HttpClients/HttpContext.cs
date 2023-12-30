using Binance.Net.Clients;
using Bybit.Net.Clients;
using OKX.Api;

namespace TradingBot.HttpClients
{
    public class HttpContext
    {
        public OKXRestApiClient Okex { get; }

        public BybitClient ByBit { get; }

        public BinanceClient Binance { get; }

        public HttpContext(OKXRestApiClient okex, BybitClient byBit, BinanceClient binance)
        {
            Okex = okex;
            ByBit = byBit;
            Binance = binance;
        }
    }
}
