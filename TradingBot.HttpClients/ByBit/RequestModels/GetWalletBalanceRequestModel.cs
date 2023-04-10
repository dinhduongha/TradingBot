using TradingBot.Core.Domain;

namespace TradingBot.HttpClients.ByBit.RequestModels
{
    public class GetWalletBalanceRequestModel
    {
        public string AccountType { get; }

        public GetWalletBalanceRequestModel(AccountType accountType)
        {
            AccountType = ByBitDictionaries.AccountTypes[accountType];
        }
    }
}
