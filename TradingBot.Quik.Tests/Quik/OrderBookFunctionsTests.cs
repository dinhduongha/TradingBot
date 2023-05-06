using QuikSharp;

namespace TradingBot.Quik.Tests.Quik
{
    public class OrderBookFunctionsTests
    {
        private readonly IOrderBookFunctions _functions;

        public OrderBookFunctionsTests(QuikSharp.Quik quik)
        {
            _functions = quik.OrderBook;
        }

        [Fact]
        public async Task GetQuoteLevel2_WithParams_ReturnNotNullResult()
        {
            var result = await _functions.GetQuoteLevel2("TQBR", "GAZP");

            Assert.NotNull(result);
        }
    }
}
