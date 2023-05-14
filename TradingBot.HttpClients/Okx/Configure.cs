using Microsoft.Extensions.DependencyInjection;
using Okex.Net;
using Okex.Net.Objects.Core;

namespace TradingBot.HttpClients.Okx
{
    internal static class Configure
    {
        public static void AddOkxHttpClients(this IServiceCollection services)
        {
            OkexClientOptions.Default.UnifiedApiOptions.BaseAddress = "https://www.okx.cab";

            services.AddSingleton(factory => new OkexClient());
        }
    }
}
