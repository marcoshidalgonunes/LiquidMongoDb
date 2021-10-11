using Liquid.Repository;
using Liquid.Repository.Mongo.Extensions;
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
