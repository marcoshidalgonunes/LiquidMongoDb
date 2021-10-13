using MediatR;

namespace Catalog.Service.Books.Request
{
    public sealed class BooksListRequest : IRequest<Response.BooksResponse>
    {
    }
}
