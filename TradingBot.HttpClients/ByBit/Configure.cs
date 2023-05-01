using Bybit.Net.Clients;
using Bybit.Net.Objects;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TradingBot.HttpClients.ByBit
{
    internal static class Configure
    {
        public static void AddByBitHttpClients(this IServiceCollection services)
        {
            BybitClientOptions.Default.LogLevel = LogLevel.Trace;

            services.AddTransient(factory => new BybitClient()); 
        }
    }
}
