using Catalog.Domain.Entity;

namespace Catalog.Service.Books.Response
{
    public sealed class BookResponse
    {
        public Book Content { get; private set; }

        public BookResponse(Book content)
        {
            Content = content;
        }
    }
}
