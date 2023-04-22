using Bybit.Net.Clients;
using Bybit.Net.Enums;

namespace TradingBot.HttpClients.Tests.ByBit
{
    public class AccountTests
    {
        private readonly BybitClient _httpClient;

        public AccountTests(BybitClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Fact]
        public async Task GetBalancesAsync_WithParams_ReturnNotNullResult()
        {
            var response = await _httpClient.V5Api.Account.GetBalancesAsync(AccountType.Spot);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);

            Assert.NotNull(response.Data.List);
            Assert.NotEmpty(response.Data.List);
        }

        [Fact]
        public async Task GetBorrowHistoryAsync_WithoutParams_ReturnNotNullResult()
        {
            var response = await _httpClient.V5Api.Account.GetBorrowHistoryAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);

            Assert.NotNull(response.Data.List);
        }

        [Fact]
        public async Task GetFeeRateAsync_WithParams_ReturnNotNullResult()
        {
            var response = await _httpClient.V5Api.Account.GetFeeRateAsync(Category.Spot);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);

            Assert.NotNull(response.Data.List);
            Assert.NotEmpty(response.Data.List);
        }

        [Fact]
        public async Task GetAssetInfoAsync_WithParams_ReturnNotNullResult()
        {
            var response = await _httpClient.V5Api.Account.GetAssetInfoAsync(AccountType.Spot);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);

            Assert.NotNull(response.Data.Assets);
            Assert.NotEmpty(response.Data.Assets);
        }
    }
}
