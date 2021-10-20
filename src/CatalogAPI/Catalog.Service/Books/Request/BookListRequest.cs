using System.Collections.Generic;
using Catalog.Domain.Entity;
using MediatR;

namespace Catalog.Service.Books.Request
{
    public sealed class BookListRequest : IRequest<IEnumerable<Book>>
    {
    }
}
