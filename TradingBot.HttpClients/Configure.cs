using Microsoft.Extensions.DependencyInjection;
using TradingBot.HttpClients.ByBit;

namespace TradingBot.HttpClients
{
    public static class Configure
    {
        public static void AddHttpClients(this IServiceCollection services)
        {
            services.AddByBitHttpClients();

            services.AddSingleton<HttpContext>();
        }
    }
}
