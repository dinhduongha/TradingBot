using QuikSharp;

namespace TradingBot.Quik.Tests.Quik
{
    public class ServiceFunctionsTests
    {
        private readonly IServiceFunctions _functions;

        public ServiceFunctionsTests(QuikSharp.Quik quik)
        {
            _functions = quik.Service;
        }

        [Fact]
        public async Task IsConnected_ReturnTrue()
        {
            var result = await _functions.IsConnected();

            Assert.True(result);
        }

        [Fact]
        public async Task GetInfoParam_WithParam_ReturnTradeDate()
        {
            var result = await _functions.GetInfoParam(InfoParams.TRADEDATE);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetInfoParam_WithParam_ReturnLocalTime()
        {
            var result = await _functions.GetInfoParam(InfoParams.LOCALTIME);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetInfoParam_WithParam_ReturnAvgPingDuration()
        {
            var result = await _functions.GetInfoParam(InfoParams.AVGPINGDURATION);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetInfoParam_WithParam_ReturnOrganization()
        {
            var result = await _functions.GetInfoParam(InfoParams.ORG);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetInfoParam_WithParam_ReturnServer()
        {
            var result = await _functions.GetInfoParam(InfoParams.SERVER);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetInfoParam_WithParam_ReturnServerTime()
        {
            var result = await _functions.GetInfoParam(InfoParams.SERVERTIME);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetInfoParam_WithParam_ReturnUser()
        {
            var result = await _functions.GetInfoParam(InfoParams.USER);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetInfoParam_WithParam_ReturnUserId()
        {
            var result = await _functions.GetInfoParam(InfoParams.USERID);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
