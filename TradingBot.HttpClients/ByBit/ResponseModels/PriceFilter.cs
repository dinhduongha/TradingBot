using Newtonsoft.Json;

namespace TradingBot.HttpClients.ByBit.ResponseModels
{
    public class PriceFilter
    {
        [JsonProperty("minPrice")]
        public string MinPrice { get; set; }

        [JsonProperty("maxPrice")]
        public string MaxPrice { get; set; }

        [JsonProperty("tickSize")]
        public string TickSize { get; set; }
    }
}
