using Binance.Net.Clients;
using Bybit.Net.Clients;
using Okex.Net;

namespace TradingBot.HttpClients
{
    public class HttpContext
    {
        public OkexClient Okex { get; }

        public BybitClient ByBit { get; }

        public BinanceClient Binance { get; }

        public HttpContext(OkexClient okex, BybitClient byBit, BinanceClient binance)
        {
            Okex = okex;
            ByBit = byBit;
            Binance = binance;
        }
    }
}
