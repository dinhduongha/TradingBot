using Newtonsoft.Json;

namespace TradingBot.HttpClients.ByBit.ResponseModels
{
    public class GetInstrumentsInfoResponseModel
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("list")]
        public IEnumerable<Instrument> Instruments { get; set; }
    }
}
