using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace Liquid.ElasticApm.Extensions
{
    /// <summary>
    /// Extends <see cref="IConfiguration"/> interface.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal static class IConfigurationExtension
    {
        /// <summary>
        /// Checks if Elastic APM is enabled.
        /// </summary>
        /// <param name="config">Extended <see cref="IConfiguration"/> instance.</param>
        /// <returns>True if Elastic APM is enabled, otherwise False.</returns>
        internal static bool HasElasticApmEnabled(this IConfiguration config) =>
            config.GetSection("ElasticApm") != null &&
            (config["ElasticApm:Enabled"] == null || (bool.TryParse(config["ElasticApm:Enabled"], out bool enabled) && enabled)) &&
            (Environment.GetEnvironmentVariable("ELASTIC_APM_ENABLED") == null || (bool.TryParse(Environment.GetEnvironmentVariable("ELASTIC_APM_ENABLED"), out bool isEnabled) && isEnabled));
    }
}
