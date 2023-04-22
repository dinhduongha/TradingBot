using Bybit.Net.Clients;

namespace TradingBot.HttpClients
{
    public class HttpContext
    {
        public BybitClient ByBit { get; }

        public HttpContext(BybitClient byBit)
        {
            ByBit = byBit;
        }
    }
}
