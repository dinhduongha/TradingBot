using Newtonsoft.Json;
using System.Net;
using TradingBot.HttpClients.Core.ResponseModels;

namespace TradingBot.HttpClients.Core.HttpResponseMapers
{
    public class JsonHttpResponseMaper : IHttpResponseMaper
    {
        public ResponseModel<TResult> Map<TResult>(string? responseContent,
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (responseContent == null) throw new ArgumentNullException(nameof(responseContent));

            return new ResponseModel<TResult>(JsonConvert.DeserializeObject<TResult>(responseContent), statusCode);
        }
    }
}
