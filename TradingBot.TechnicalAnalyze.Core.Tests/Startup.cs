using Microsoft.Extensions.DependencyInjection;
using TradingBot.Core.Configuration.Api;
using TradingBot.Core.Configuration;
using TradingBot.HttpClients;

namespace TradingBot.TechnicalAnalyze.Core.Tests
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IApiKey, ByBitApiKey>(provider => new ByBitApiKey("5WtwNTNXdIAJvwOa8x",
                "nKHRZBUqkPEFpVh296Ldr1TSgsv2kU3RGxdU"));

            services.AddHttpClients();
        }
    }
}
