using Newtonsoft.Json;

namespace TradingBot.HttpClients.ByBit.ResponseModels
{
    public class LeverageFilter
    {
        [JsonProperty("minLeverage")]
        public string MinLeverage { get; set; }

        [JsonProperty("maxLeverage")]
        public string MaxLeverage { get; set; }

        [JsonProperty("leverageStep")]
        public string LeverageStep { get; set; }
    }
}
