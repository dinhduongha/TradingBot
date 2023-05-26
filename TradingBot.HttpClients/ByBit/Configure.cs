using Bybit.Net.Clients;
using Microsoft.Extensions.DependencyInjection;
using TradingBot.CryptoExchanges.ByBit;

namespace TradingBot.HttpClients.ByBit
{
    internal static class Configure
    {
        public static void AddByBitHttpClients(this IServiceCollection services)
        {
            services.AddSingleton(factory => new BybitClient());
            services.AddSingleton(factory => new ByBitConverter());
        }
    }
}
