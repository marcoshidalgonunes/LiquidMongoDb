using System.Collections.Generic;

namespace Catalog.Service.Books.Response
{
    public sealed class BooksResponse
    {
        public IEnumerable<Entity.Book> Response { get; private set; }

        public BooksResponse(IEnumerable<Entity.Book> response)
        {
            Response = response;
        }
    }
}
