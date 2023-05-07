using QuikSharp;
using System.Diagnostics;

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
            var watch = new Stopwatch();
            var pings = new List<long>();

            for (var i = 0; i < 10; i++)
            {
                watch.Reset();
                watch.Start();

                await _functions.Ping();

                watch.Stop();

                pings.Add(watch.ElapsedMilliseconds);
            }

            var avgPing = pings.Average();

            Assert.True(avgPing > 0);
        }
    }
}
