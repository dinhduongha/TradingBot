using Newtonsoft.Json;
using System.Net;
using TradingBot.HttpClients.Core;
using TradingBot.HttpClients.Core.ResponseModels;

namespace TradingBot.HttpClients.ByBit
{
    internal class ByBitHttpResponseMaper : IHttpResponseMaper
    {
        public ResponseModel<TResult> Map<TResult>(string? responseContent, 
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (responseContent == null) throw new ArgumentNullException(nameof(responseContent));

            var response = JsonConvert.DeserializeObject<ByBitResponseModel<TResult>>(responseContent);

            return new ResponseModel<TResult>(response.Result, statusCode);
        }
    }
}
