using System.Collections.Generic;
using Catalog.Service.Entity;

namespace Catalog.Service.Books
{
    public sealed class BooksResponse
    {
        public IEnumerable<Book> Response { get; private set; }

        public BooksResponse(IEnumerable<Book> response)
        {
            Response = response;
        }
    }
}
