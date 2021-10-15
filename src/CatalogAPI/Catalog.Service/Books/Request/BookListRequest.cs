using MediatR;

namespace Catalog.Service.Books.Request
{
    public sealed class BookListRequest : IRequest<Response.BookQueryResponse>
    {
    }
}
