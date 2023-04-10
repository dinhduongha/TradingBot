using Microsoft.Extensions.DependencyInjection;
using TradingBot.Core.Configuration;
using TradingBot.Core.Configuration.Api;

namespace TradingBot.HttpClients.Tests
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IApiKey, ByBitApiKey>(provider => new ByBitApiKey("", ""));

            services.AddHttpClients();
        }
    }
}
