﻿using Liquid.Repository;

namespace Catalog.Service.Entity
{
    public sealed class Book : LiquidEntity<string>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}
