using TradingBot.Core.Configuration;
using TradingBot.Core.Extensions;
using TradingBot.HttpClients.ByBit.RequestModels;
using TradingBot.HttpClients.ByBit.ResponseModels;
using TradingBot.HttpClients.Core.ResponseModels;

namespace TradingBot.HttpClients.ByBit
{
    public class AccountHttpClient : ByBitHttpClient
    {
        public AccountHttpClient(IApiKey apiKey) : base(apiKey, ByBitRoutes.AccountPath + "/")
        {

        }

        public async Task<ResponseModel<GetWalletBalanceResponseModel>> GetWalletBalanceAsync(
            GetWalletBalanceRequestModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return await GetAsync<GetWalletBalanceResponseModel>(ByBitRoutes.AccountGetWalletBalanceQuery
                .Inject(model));
        }
    }
}
