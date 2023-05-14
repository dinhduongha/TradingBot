using Microsoft.Extensions.DependencyInjection;
using TradingBot.HttpClients.Binance;
using TradingBot.HttpClients.ByBit;
using TradingBot.HttpClients.Okx;

namespace TradingBot.HttpClients
{
    public static class Configure
    {
        public static void AddHttpClients(this IServiceCollection services)
        {
            services.AddOkxHttpClients();
            services.AddByBitHttpClients();
            services.AddBinanceHttpClients();

            services.AddSingleton<HttpContext>();
        }
    }
}
