using Newtonsoft.Json;
using System.Collections.Generic;

namespace TradingBot.HttpClients.ByBit.ResponseModels
{
    public class GetWalletBalanceResponseModel
    {
        [JsonProperty("list")]
        public IEnumerable<Wallet> Wallets { get; set; }
    }
}
