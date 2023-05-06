using Microsoft.Extensions.DependencyInjection;

namespace TradingBot.HttpClients.Tests
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClients();
        }
    }
}
