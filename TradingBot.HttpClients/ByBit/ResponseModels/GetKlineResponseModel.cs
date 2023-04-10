using Newtonsoft.Json;

namespace TradingBot.HttpClients.ByBit.ResponseModels
{
    public class GetKlineResponseModel
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("nextPageCursor")]
        public string NextPageCursor { get; set; }

        [JsonProperty("list")]
        public IEnumerable<string[]> Values { get; set; }
    }
}
