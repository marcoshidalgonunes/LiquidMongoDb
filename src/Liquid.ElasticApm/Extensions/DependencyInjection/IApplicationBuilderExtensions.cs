using System.Diagnostics.CodeAnalysis;
using Elastic.Apm;
using Elastic.Apm.NetCoreAll;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Liquid.ElasticApm.Extensions.DependencyInjection
{
    /// <summary>
    /// .Net application builder extensions class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class IApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds <see cref="UseAllElasticApm"/> to the application builder.
        /// </summary>
        /// <param name="builder">Extended application builder.</param>
        /// <param name="configuration"><see cref="IConfiguration"/> implementation.</param>
        public static IApplicationBuilder UseLiquidElasticApm(this IApplicationBuilder builder, IConfiguration configuration)
        {
            //if (Agent.Config.Enabled)
            //{
            //    builder.UseAllElasticApm(configuration);
            //}

            builder.UseAllElasticApm(configuration);

            return builder;
        }
    }
}
