using Newtonsoft.Json;
using System.Net;
using TradingBot.HttpClients.Core.ResponseModels;

namespace TradingBot.HttpClients.Core.HttpResponseMapers
{
    public class AutoWrapperHttpResponseMaper : IHttpResponseMaper
    {
        public ResponseModel<TResult> Map<TResult>(string? responseContent,
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (responseContent == null) throw new ArgumentNullException(nameof(responseContent));

            return JsonConvert.DeserializeObject<ResponseModel<TResult>>(responseContent);
        }
    }
}
