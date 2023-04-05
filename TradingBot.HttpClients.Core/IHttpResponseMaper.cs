using System.Net;
using TradingBot.HttpClients.Core.ResponseModels;

namespace TradingBot.HttpClients.Core
{
    public interface IHttpResponseMaper
    {
        ResponseModel<TResult> Map<TResult>(string? responseContent, HttpStatusCode statusCode = HttpStatusCode.OK);
    }
}
