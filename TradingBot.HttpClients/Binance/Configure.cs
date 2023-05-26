using Binance.Net.Clients;
using Microsoft.Extensions.DependencyInjection;
using TradingBot.CryptoExchanges.Binance;

namespace TradingBot.HttpClients.Binance
{
    internal static class Configure
    {
        public static void AddBinanceHttpClients(this IServiceCollection services)
        {
            services.AddSingleton(factory => new BinanceClient());
            services.AddSingleton(factory => new BinanceConverter());
        }
    }
}
