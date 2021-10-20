using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Liquid.Repository;
using MediatR;

namespace Catalog.Service.Books.Handler
{
    public abstract class BaseBookQueryRequestHandler<TRequest> : IRequestHandler<TRequest, IEnumerable<Book>>
        where TRequest : IRequest<IEnumerable<Book>>
    {
        protected readonly ILiquidRepository<Book, string> BooksRepository;

        public BaseBookQueryRequestHandler(ILiquidRepository<Book, string> booksRepository)
        {
            BooksRepository = booksRepository;
        }

        public abstract Task<IEnumerable<Book>> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
