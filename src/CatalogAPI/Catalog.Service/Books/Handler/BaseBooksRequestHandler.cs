using System.Threading;
using System.Threading.Tasks;
using Catalog.Service.Books.Request;
using Catalog.Service.Books.Response;
using Catalog.Service.Entity;
using Liquid.Repository;
using MediatR;

namespace Catalog.Service.Books.Handler
{
    public abstract class BaseBooksRequestHandler : IRequestHandler<Request.BooksListRequest, Response.BooksResponse>
    {
        protected readonly ILiquidRepository<Book, string> BooksRepository;

        public BaseBooksRequestHandler(ILiquidRepository<Book, string> booksRepository)
        {
            BooksRepository = booksRepository;
        }

        public abstract Task<BooksResponse> Handle(BooksListRequest request, CancellationToken cancellationToken);
    }
}
