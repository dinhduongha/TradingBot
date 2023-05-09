using Microsoft.Extensions.DependencyInjection;
using TradingBot.HttpClients;

namespace TradingBot.ExchangeSimulator.Tests
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClients();
        }
    }
}
