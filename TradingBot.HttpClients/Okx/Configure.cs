using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Okex.Net;
using Okex.Net.Objects.Core;

namespace TradingBot.HttpClients.Okx
{
    internal static class Configure
    {
        public static void AddOkxHttpClients(this IServiceCollection services)
        {
            OkexClientOptions.Default.UnifiedApiOptions.BaseAddress = "https://www.okx.cab";
            OkexClientOptions.Default.LogLevel = LogLevel.Trace;

            services.AddTransient(factory => new OkexClient());
        }
    }
}
