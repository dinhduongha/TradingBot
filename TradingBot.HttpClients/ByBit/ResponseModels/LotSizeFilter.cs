using Newtonsoft.Json;

namespace TradingBot.HttpClients.ByBit.ResponseModels
{
    public class LotSizeFilter
    {
        [JsonProperty("basePrecision")]
        public string BasePrecision { get; set; }

        [JsonProperty("quotePrecision")]
        public string QuotePrecision { get; set; }

        [JsonProperty("minOrderQty")]
        public string MinOrderQty { get; set; }

        [JsonProperty("maxOrderQty")]
        public string MaxOrderQty { get; set; }

        [JsonProperty("minOrderAmt")]
        public string MinOrderAmt { get; set; }

        [JsonProperty("maxOrderAmt")]
        public string MaxOrderAmt { get; set; }

        [JsonProperty("qtyStep")]
        public string QtyStep { get; set; }

        [JsonProperty("postOnlyMaxOrderQty")]
        public string PostOnlyMaxOrderQty { get; set; }
    }
}
