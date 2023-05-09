using Microsoft.Extensions.DependencyInjection;
using TradingBot.HttpClients;

namespace TradingBot.TradingStrategiesTester.Tests
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClients();
        }
    }
}
