using Elastic.Apm;
using Liquid.Core.Extensions.DependencyInjection;
using Liquid.ElasticApm.Core.Implementations;
using Liquid.ElasticApm.MediatR;
using MediatR;
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
        /// <param name="services">Extended IServiceCollection instance.</param>
        public static IServiceCollection AddElasticApmTelemetry(this IServiceCollection services)
        {
            //if (Agent.Config.Enabled)
            //{
            //}

            services.AddSingleton(s => Agent.Tracer);

            services.AddInterceptor<LiquidElasticApmInterceptor>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            return services;
        }
    }
}
