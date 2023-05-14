using Microsoft.Extensions.DependencyInjection;
using TradingBot.HttpClients;

namespace TradingBot.TechnicalAnalyze.Tests
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClients();
        }
    }
}
