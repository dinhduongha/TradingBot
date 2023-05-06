using QuikSharp;

namespace TradingBot.Quik.Tests.Quik
{
    public class DebugFunctionsTests
    {
        private readonly DebugFunctions _functions;

        public DebugFunctionsTests(QuikSharp.Quik quik)
        {
            _functions = quik.Debug;
        }

        [Fact]
        public async Task Ping_ReturnNotNullAndEmptyResult()
        {
            var result = await _functions.Ping();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
