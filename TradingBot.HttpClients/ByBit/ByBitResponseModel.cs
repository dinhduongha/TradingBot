using Newtonsoft.Json;

namespace TradingBot.HttpClients.ByBit
{
    internal class ByBitResponseModel<TResult>
    {
        [JsonProperty("retMsg")]
        public string Message { get; }

        [JsonProperty("result")]
        public TResult? Result { get; }

        [JsonProperty("retExtInfo")]
        public object? ExtendInfo { get; }
    }
}
