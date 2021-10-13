using MediatR;
using MongoDB.Bson;

namespace Catalog.Service.Books.Request
{
    public class BookFindRequest : IRequest<Response.BookResponse>
    {
        public string Id { get; private set; }

        public BookFindRequest(string id)
        {
            Id = id;
        }
    }
}
