using Catalog.Domain.Entity;
using MediatR;

namespace Catalog.Service.Books.Request
{
    public abstract class BaseBookEditRequest : IRequest<string>
    {
        public Book Request { get; private set; }

        public BaseBookEditRequest(Book request)
        {
            Request = request;
        }
    }
}
