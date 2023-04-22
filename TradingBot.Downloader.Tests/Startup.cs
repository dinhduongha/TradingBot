using Bybit.Net.Clients;
using Bybit.Net.Objects;
using CryptoExchange.Net.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TradingBot.HttpClients;

namespace TradingBot.Downloader.Tests
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            BybitClient.SetDefaultOptions(new BybitClientOptions
            {
                ApiCredentials = new ApiCredentials("API-KEY", "API-SECRET"),
                LogLevel = LogLevel.Trace,
            });

            services.AddHttpClients();
        }
    }
}
