using QuikSharp;

namespace TradingBot.Quik.Tests.Quik
{
    public class TradingFunctionsTests
    {
        private readonly ITradingFunctions _functions;

        public TradingFunctionsTests(QuikSharp.Quik quik)
        {
            _functions = quik.Trading;
        }

        [Fact]
        public async Task GetDepoLimits_WithoutParam_ReturnNotNullAndNotEmptyResult()
        {
            var result = await _functions.GetDepoLimits();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetDepoLimits_WithParam_ReturnNotNullResult()
        {
            var result = await _functions.GetDepoLimits("TQBR");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetMoneyLimits_ReturnNotNullAndNotEmptyResult()
        {
            var result = await _functions.GetMoneyLimits();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetTrades_WithoutParams_ReturnNotNullResult()
        {
            var result = await _functions.GetTrades();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetTrades_WithParams_ReturnNotNullResult()
        {
            var result = await _functions.GetTrades("TQBR", "GAZP");

            Assert.NotNull(result);
        }
    }
}
