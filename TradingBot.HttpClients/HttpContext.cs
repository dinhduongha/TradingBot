using TradingBot.HttpClients.ByBit;

namespace TradingBot.HttpClients
{
    public class HttpContext
    {
        public ByBitHttpContext ByBit { get; }

        public HttpContext(ByBitHttpContext byBit)
        {
            ByBit = byBit;
        }
    }
}
