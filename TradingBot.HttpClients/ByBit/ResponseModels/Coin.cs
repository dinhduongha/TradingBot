using Newtonsoft.Json;

namespace TradingBot.HttpClients.ByBit.ResponseModels
{
    public class Coin
    {
        [JsonProperty("availableToBorrow")]
        public string AvailableToBorrow { get; set; }

        [JsonProperty("bonus")]
        public string Bonus { get; set; }

        [JsonProperty("accruedInterest")]
        public string AccruedInterest { get; set; }

        [JsonProperty("availableToWithdraw")]
        public string AvailableToWithdraw { get; set; }

        [JsonProperty("totalOrderIM")]
        public string TotalOrderIM { get; set; }

        [JsonProperty("equity")]
        public string Equity { get; set; }

        [JsonProperty("totalPositionMM")]
        public string TotalPositionMM { get; set; }

        [JsonProperty("usdValue")]
        public string UsdValue { get; set; }

        [JsonProperty("unrealisedPnl")]
        public string UnrealisedPnl { get; set; }

        [JsonProperty("borrowAmount")]
        public string BorrowAmount { get; set; }

        [JsonProperty("totalPositionIM")]
        public string TotalPositionIM { get; set; }

        [JsonProperty("walletBalance")]
        public string WalletBalance { get; set; }

        [JsonProperty("cumRealisedPnl")]
        public string CumRealisedPnl { get; set; }

        [JsonProperty("coin")]
        public string Name { get; set; }
    }
}