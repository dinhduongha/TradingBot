using Newtonsoft.Json;

namespace TradingBot.HttpClients.ByBit.ResponseModels
{
    public class GetTickersResponseModel
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("list")]
        public IEnumerable<Ticker> Tickers { get; set; }
    }
}
