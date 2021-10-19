using Catalog.Domain.Entity;
using MediatR;

namespace Catalog.Service.Books.Request
{
    public sealed class BookDeleteRequest : IRequest<string>
    {
        public string Id { get; private set; }

        public BookDeleteRequest(string id)
        {
            Id = id;
        }
    }
}
