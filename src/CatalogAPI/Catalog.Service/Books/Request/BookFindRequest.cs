using Catalog.Domain.Entity;
using MediatR;

namespace Catalog.Service.Books.Request
{
    public class BookFindRequest : IRequest<Book>
    {
        public string Id { get; private set; }

        public BookFindRequest(string id)
        {
            Id = id;
        }
    }
}
