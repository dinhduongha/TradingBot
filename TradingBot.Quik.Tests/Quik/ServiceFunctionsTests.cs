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
    }
}
