using Microsoft.Extensions.DependencyInjection;

namespace TradingBot.Infrastructure.Tests
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure();
        }
    }
}
