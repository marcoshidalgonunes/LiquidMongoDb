using MediatR;

namespace Catalog.Service.Books.Request
{
    public sealed class BookDeleteRequest : IRequest
    {
        public string Id { get; private set; }

        public BookDeleteRequest(string id)
        {
            Id = id;
        }
    }
}
