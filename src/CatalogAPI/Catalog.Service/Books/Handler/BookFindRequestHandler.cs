using System.Threading;
using System.Threading.Tasks;
using Liquid.Repository;
using MediatR;

namespace Catalog.Service.Books.Handler
{
    public sealed class BookFindRequestHandler : IRequestHandler<Request.BookFindRequest, Response.BookResponse>
    {
        private readonly ILiquidRepository<Entity.Book, string> _booksRepository;

        public BookFindRequestHandler(ILiquidRepository<Entity.Book, string> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<Response.BookResponse> Handle(Request.BookFindRequest request, CancellationToken cancellationToken)
        {
            var book = await _booksRepository.FindByIdAsync(request.Id);

            var response = new Response.BookResponse(book);

            return response;
        }
    }
}
