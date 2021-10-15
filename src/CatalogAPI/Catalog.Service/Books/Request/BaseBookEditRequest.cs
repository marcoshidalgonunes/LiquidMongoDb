using Catalog.Domain.Entity;
using MediatR;

namespace Catalog.Service.Books.Request
{
    public abstract class BaseBookEditRequest : IRequest<Book>
    {
        public Book Request { get; private set; }

        public BaseBookEditRequest(Book request)
        {
            Request = request;
        }
    }
}
