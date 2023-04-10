using Newtonsoft.Json;

namespace TradingBot.HttpClients.ByBit
{
    internal class ByBitResponseModel<TResult>
    {
        [JsonProperty("retMsg")]
        public string Message { get; set; }

        [JsonProperty("result")]
        public TResult? Result { get; set; }

        [JsonProperty("retExtInfo")]
        public object? ExtendInfo { get; set; }
    }
}
