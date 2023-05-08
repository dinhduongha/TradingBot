using Microsoft.Extensions.DependencyInjection;
using TradingBot.HttpClients;
using TradingBot.Quik;

namespace TradingBot.Downloader.Tests
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClients();
        }
    }
}
