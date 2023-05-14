using QuikSharp;
using QuikSharp.DataStructures;

namespace TradingBot.Quik.Tests.Quik
{
    public class CandleFunctionsTests
    {
        private readonly CandleFunctions _functions;

        public CandleFunctionsTests(QuikSharp.Quik quik)
        {
            _functions = quik.Candles;
        }

        [Fact]
        public async Task GetAllCandles_WithParams_ReturnNotNullAndNotEmptyResult()
        {
            var result = await _functions.GetAllCandles("TQBR", "GAZP", CandleInterval.MN);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetLastCandles_WithParams_ReturnNotNullAndNotEmptyResult()
        {
            var result = await _functions.GetLastCandles("TQBR", "GAZP", CandleInterval.M1, 1000);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
