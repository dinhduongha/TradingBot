using TradingBot.Core.Domain;
using TradingBot.HttpClients.ByBit;
using TradingBot.HttpClients.ByBit.RequestModels;
using Xunit;

namespace TradingBot.HttpClients.Tests.ByBit
{
    public class AccountHttpClientTests
    {
        private readonly AccountHttpClient _httpClient;

        public AccountHttpClientTests(AccountHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Fact]
        public async Task GetWalletBalanceAsync_WithModel_ReturnNotNullAndEmptyResponse()
        {
            var model = new GetWalletBalanceRequestModel(AccountType.Spot);

            var response = await _httpClient.GetWalletBalanceAsync(model);

            Assert.NotNull(response);

            Assert.NotNull(response.Result);

            Assert.NotNull(response.Result.Wallets);
            Assert.NotEmpty(response.Result.Wallets);
        }
    }
}
