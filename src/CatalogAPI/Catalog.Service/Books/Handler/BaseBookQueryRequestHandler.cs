using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Catalog.Service.Books.Response;
using Liquid.Repository;
using MediatR;

namespace Catalog.Service.Books.Handler
{
    public abstract class BaseBookQueryRequestHandler<TRequest> : IRequestHandler<TRequest, BookQueryResponse>
        where TRequest : IRequest<BookQueryResponse>
    {
        protected readonly ILiquidRepository<Book, string> BooksRepository;

        public BaseBookQueryRequestHandler(ILiquidRepository<Book, string> booksRepository)
        {
            BooksRepository = booksRepository;
        }

        public abstract Task<BookQueryResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
