using Microsoft.Extensions.DependencyInjection;

namespace TradingBot.HttpClients
{
    public static class Configure
    {
        public static void AddHttpClients(this IServiceCollection services)
        {
            services.AddSingleton<HttpContext>();
        }
    }
}
