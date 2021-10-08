using System.Collections.Generic;
using Catalog.Service.Entity;
using MediatR;

namespace Catalog.Service.Books
{
    public sealed class BooksRequest : IRequest<List<Book>>
    {
    }
}
