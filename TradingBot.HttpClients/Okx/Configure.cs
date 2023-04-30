using Microsoft.Extensions.DependencyInjection;
using Okex.Net;

namespace TradingBot.HttpClients.Okx
{
    internal static class Configure
    {
        public static void AddOkxHttpClients(this IServiceCollection services)
        {
            services.AddTransient(factory => new OkexClient());
        }
    }
}
