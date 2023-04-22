using Bybit.Net.Clients;
using Bybit.Net.Objects;
using CryptoExchange.Net.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TradingBot.Infrastructure.Tests
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            BybitClient.SetDefaultOptions(new BybitClientOptions
            {
                ApiCredentials = new ApiCredentials("5WtwNTNXdIAJvwOa8x", "nKHRZBUqkPEFpVh296Ldr1TSgsv2kU3RGxdU"),
                LogLevel = LogLevel.Trace,
            });

            services.AddInfrastructure();
        }
    }
}
