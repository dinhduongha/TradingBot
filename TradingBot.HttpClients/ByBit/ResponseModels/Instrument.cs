using Newtonsoft.Json;

namespace TradingBot.HttpClients.ByBit.ResponseModels
{
    public class Instrument 
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("baseCoin")]
        public string BaseCoin { get; set; }

        [JsonProperty("quoteCoin")]
        public string QuoteCoin { get; set; }

        [JsonProperty("innovation")]
        public string Innovation { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("contractType")]
        public string ContractType { get; set; }

        [JsonProperty("launchTime")]
        public string LaunchTime { get; set; }

        [JsonProperty("deliveryTime")]
        public string DeliveryTime { get; set; }

        [JsonProperty("deliveryFeeRate")]
        public string DeliveryFeeRate { get; set; }

        [JsonProperty("priceScale")]
        public string PriceScale { get; set; }

        [JsonProperty("unifiedMarginTrade")]
        public bool UnifiedMarginTrade { get; set; }

        [JsonProperty("fundingInterval")]
        public int FundingInterval { get; set; }

        [JsonProperty("settleCoin")]
        public string SettleCoin { get; set; }

        [JsonProperty("leverageFilter")]
        public LeverageFilter LeverageFilter { get; set; }

        [JsonProperty("lotSizeFilter")]
        public LotSizeFilter LotSizeFilter { get; set; }

        [JsonProperty("priceFilter")]
        public PriceFilter PriceFilter { get; set; }
    }
}
