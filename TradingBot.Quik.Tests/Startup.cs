using Microsoft.Extensions.DependencyInjection;

namespace TradingBot.Quik.Tests
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddQuik();
        }
    }
}
