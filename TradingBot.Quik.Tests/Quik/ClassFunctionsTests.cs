using QuikSharp;

namespace TradingBot.Quik.Tests.Quik
{
    public class ClassFunctionsTests
    {
        private readonly IClassFunctions _functions;

        public ClassFunctionsTests(QuikSharp.Quik quik)
        {
            _functions = quik.Class;
        }

        [Fact]
        public async Task GetClassesList_ReturnNotNullAndNotEmptyResult()
        {
            var result = await _functions.GetClassesList();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetSecurityClass_WithParams_ReturnNotNullAndNotEmptyResult()
        {
            var result = await _functions.GetSecurityClass("TQBR", "GAZP");

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetClientCode_ReturnNotNullAndNotEmptyResult()
        {
            var result = await _functions.GetClientCode();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetClassInfo_WithParam_ReturnNotNullResult()
        {
            var result = await _functions.GetClassInfo("TQBR");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetSecurityInfo_WithParams_ReturnNotNullResult()
        {
            var result = await _functions.GetSecurityInfo("TQBR", "GAZP");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetClassSecurities_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var result = await _functions.GetClassSecurities("TQBR");

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetTradeAccount_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var result = await _functions.GetTradeAccount("GAZP");

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetTradeAccounts_ReturnNotNullAndNotEmptyResult()
        {
            var result = await _functions.GetTradeAccounts();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
