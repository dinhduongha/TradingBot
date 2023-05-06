using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace TradingBot.Quik
{
    public static class Configure
    {
        public static void AddQuik(this IServiceCollection services)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            services.AddSingleton(factory => new QuikSharp.Quik());
        }
    }
}
