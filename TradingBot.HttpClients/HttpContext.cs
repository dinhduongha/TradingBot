using Binance.Net.Clients;
using Bitfinex.Net.Clients;
using Bybit.Net.Clients;
using Okex.Net;

namespace TradingBot.HttpClients
{
    public class HttpContext
    {
        public OkexClient Okex { get; }

        public BybitClient ByBit { get; }

        public BinanceClient Binance { get; }

        public BitfinexClient Bitfinex { get; }

        public HttpContext(OkexClient okex, BybitClient byBit, BinanceClient binance, BitfinexClient bitfinex)
        {
            Okex = okex;
            ByBit = byBit;
            Binance = binance;
            Bitfinex = bitfinex;
        }
    }
}
