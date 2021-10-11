using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liquid.Core.Exceptions;
using Liquid.Core.Implementations;
using Liquid.Core.Interfaces;
using Liquid.Repository;
using Liquid.Repository.Configuration;
using Liquid.Repository.Mongo.Configuration;
using Liquid.Repository.Mongo.Extensions;
using Liquid.WebApi.Http.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.API.Configuration
{
    internal static class Repository
    {
        public static IServiceCollection AddLiquidMongoDatabaseWithTelemetry<TEntity, TIdentifier>(this IServiceCollection services, string databaseName)
            where TEntity : LiquidEntity<TIdentifier>, new()
        {
            services.AddLiquidMongoWithTelemetry<TEntity, TIdentifier>(options => { options.DatabaseName = databaseName; options.CollectionName = typeof(TEntity).Name + "s"; options.ShardKey = "id"; });

            return services;
        }
    }
}
