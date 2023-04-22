using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TradingBot.HttpClients;
using TradingBot.Infrastructure.Pipelines;

namespace TradingBot.Infrastructure
{
    public static class Configure
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClients();

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(Configure).Assembly);
            });
            services.AddValidatorsFromAssembly(typeof(Configure).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipe<,>));
        }
    }
}
