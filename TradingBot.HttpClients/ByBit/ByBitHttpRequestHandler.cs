using TradingBot.HttpClients.Core;
using TradingBot.HttpClients.Core.HttpRequestHandlers;

namespace TradingBot.HttpClients.ByBit
{
    internal class ByBitHttpRequestHandler : BaseHttpRequestHandler
    {
        public override IHttpResponseMaper Maper => new ByBitHttpResponseMaper();
    }
}
