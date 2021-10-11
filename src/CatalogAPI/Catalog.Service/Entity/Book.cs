using System;
using Liquid.Repository;
using MongoDB.Bson;

namespace Catalog.Service.Entity
{
    public sealed class Book : LiquidEntity<ObjectId>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}
