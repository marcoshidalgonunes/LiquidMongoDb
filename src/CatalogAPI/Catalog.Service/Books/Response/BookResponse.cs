using Catalog.Domain.Entity;

namespace Catalog.Service.Books.Response
{
    public sealed class BookResponse
    {
        public Book Response { get; private set; }

        public BookResponse(Book response)
        {
            Response = response;
        }
    }
}
