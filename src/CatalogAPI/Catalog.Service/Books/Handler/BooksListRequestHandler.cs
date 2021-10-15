using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Liquid.Repository;
using MediatR;

namespace Catalog.Service.Books.Handler
{
    public sealed class BooksListRequestHandler : IRequestHandler<Request.BookListRequest, Response.BookQueryResponse>
    {
        private readonly ILiquidRepository<Book, string> _booksRepository;

        public BooksListRequestHandler(ILiquidRepository<Book, string> booksRepository)
        {
            _booksRepository = booksRepository;
        }
            
        public async Task<Response.BookQueryResponse> Handle(Request.BookListRequest request, CancellationToken cancellationToken)
        {
            var items = await _booksRepository.FindAllAsync();

            var response = new Response.BookQueryResponse(items);

            return response; 
        }
    }
}
