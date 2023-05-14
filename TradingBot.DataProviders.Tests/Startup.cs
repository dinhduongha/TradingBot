using Microsoft.Extensions.DependencyInjection;
using TradingBot.HttpClients;

namespace TradingBot.DataProviders.Tests
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClients();
        }
    }
}
