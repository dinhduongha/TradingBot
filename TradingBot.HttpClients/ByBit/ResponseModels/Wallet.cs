using Newtonsoft.Json;

namespace TradingBot.HttpClients.ByBit.ResponseModels
{
    public class Wallet
    {
        [JsonProperty("totalEquity")]
        public string TotalEquity { get; set; }

        [JsonProperty("accountIMRate")]
        public string AccountIMRate { get; set; }

        [JsonProperty("totalMarginBalance")]
        public string TotalMarginBalance { get; set; }

        [JsonProperty("totalInitialMargin")]
        public string TotalInitialMargin { get; set; }

        [JsonProperty("accountType")]
        public string AccountType { get; set; }

        [JsonProperty("totalAvailableBalance")]
        public string TotalAvailableBalance { get; set; }

        [JsonProperty("accountMMRate")]
        public string AccountMMRate { get; set; }

        [JsonProperty("totalPerpUPL")]
        public string TotalPerpUPL { get; set; }

        [JsonProperty("totalWalletBalance")]
        public string TotalWalletBalance { get; set; }

        [JsonProperty("accountLTV")]
        public string AccountLTV { get; set; }

        [JsonProperty("totalMaintenanceMargin")]
        public string TotalMaintenanceMargin { get; set; }

        [JsonProperty("coin")]
        public IEnumerable<Coin> Coin { get; set; }
    }
}