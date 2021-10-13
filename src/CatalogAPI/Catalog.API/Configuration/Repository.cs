using Liquid.Repository;
using Liquid.Repository.Mongo.Extensions;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Catalog.API.Configuration
{
    internal static class Repository
    {
        public static IServiceCollection AddLiquidMongoDatabaseWithTelemetry<TEntity, TIdentifier>(this IServiceCollection services, string databaseName)
            where TEntity : LiquidEntity<TIdentifier>, new()
        {
            BsonClassMap.RegisterClassMap<LiquidEntity<TIdentifier>>(map => {
                map.AutoMap();
                map.MapIdMember(m => m.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
                map.MapMember(m => m.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
            });

            services.AddLiquidMongoWithTelemetry<TEntity, TIdentifier>(options => { options.DatabaseName = databaseName; options.CollectionName = typeof(TEntity).Name + "s"; options.ShardKey = "id"; });

            return services;
        }
    }
}
