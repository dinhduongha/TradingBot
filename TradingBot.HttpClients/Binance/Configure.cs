using Binance.Net.Clients;
using Binance.Net.Objects;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TradingBot.HttpClients.Binance
{
    internal static class Configure
    {
        public static void AddBinanceHttpClients(this IServiceCollection services)
        {
            BinanceClientOptions.Default.LogLevel = LogLevel.Trace;

            services.AddSingleton(factory => new BinanceClient());
        }
    }
}
