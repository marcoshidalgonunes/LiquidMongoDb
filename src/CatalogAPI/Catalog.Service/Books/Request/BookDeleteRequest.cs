using MediatR;
using MongoDB.Bson;

namespace Catalog.Service.Books.Request
{
    public sealed class BookDeleteRequest : IRequest
    {
        public ObjectId Id { get; private set; }

        public BookDeleteRequest(string id)
        {
            Id = new ObjectId(id);
        }
    }
}
