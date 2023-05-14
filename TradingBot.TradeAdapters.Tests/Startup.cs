using Microsoft.Extensions.DependencyInjection;
using Okex.Net.Objects.Core;
using TradingBot.HttpClients;
using TradingBot.Quik;

namespace TradingBot.TradeAdapters.Tests
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClients();
            services.AddQuik();
        }
    }
}
