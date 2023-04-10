using Newtonsoft.Json;

namespace TradingBot.HttpClients.ByBit.ResponseModels
{
    public class GetOrderbookResponseModel
    {
        [JsonProperty("u")]
        public int UpdateId { get; set; }

        [JsonProperty("ts")]
        public long Timestamp { get; set; }

        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("b")]
        public IEnumerable<string[]> Buyers { get; set; }

        [JsonProperty("a")]
        public IEnumerable<string[]> Sellers { get; set; }
    }
}
