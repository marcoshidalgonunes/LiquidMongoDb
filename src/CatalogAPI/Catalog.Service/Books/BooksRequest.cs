using MediatR;

namespace Catalog.Service.Books
{
    public sealed class BooksRequest : IRequest<BooksResponse>
    {
    }
}
