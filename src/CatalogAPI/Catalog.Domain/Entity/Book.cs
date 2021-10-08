using System;
using Liquid.Repository;

namespace Catalog.Domain.Entity
{
    public sealed class Book : LiquidEntity<Guid>
    {
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}
