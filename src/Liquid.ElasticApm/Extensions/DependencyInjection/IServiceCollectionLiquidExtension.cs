using Elastic.Apm;
using Liquid.Core.Extensions.DependencyInjection;
using Liquid.ElasticApm.Core.Implementations;
using Liquid.ElasticApm.MediatR;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Liquid.ElasticApm.Extensions.DependencyInjection
{
    /// <summary>
    /// Extends <see cref="IServiceCollection"/> interface.
    /// </summary>
    public static class IServiceCollectionLiquidExtension
    {
        /// <summary>
        /// Register telemetry interceptor <see cref="LiquidElasticApmInterceptor"/> and behaviour <see cref="LoggingBehaviour"/> for Elastic APM. 
        /// </summary>
        /// <param name="services">Extended <see cref="IServiceCollection"/> instance.</param>
        public static IServiceCollection AddElasticApmTelemetry(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.HasElasticApmEnabled())
            {
                services.AddSingleton(s => Agent.Tracer);

                services.AddInterceptor<LiquidElasticApmInterceptor>();

                services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            }

            return services;
        }
    }
}
