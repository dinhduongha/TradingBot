using Bitfinex.Net.Clients;
using Microsoft.Extensions.DependencyInjection;
using TradingBot.CryptoExchanges.Bitfinex;

namespace TradingBot.HttpClients.Bitfinex
{
    internal static class Configure
    {
        public static void AddBitfinexHttpClients(this IServiceCollection services)
        {
            services.AddSingleton(factory => new BitfinexClient());
            services.AddSingleton(factory => new BitfinexConverter());
        }
    }
}
