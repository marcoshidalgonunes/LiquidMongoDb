using System.Collections.Generic;
using Catalog.Domain.Entity;

namespace Catalog.Service.Books.Response
{
    public sealed class BookQueryResponse
    {
        public IEnumerable<Book> Response { get; private set; }

        public BookQueryResponse(IEnumerable<Book> response)
        {
            Response = response;
        }
    }
}
