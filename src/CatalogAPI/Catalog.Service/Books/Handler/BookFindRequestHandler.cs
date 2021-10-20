using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Liquid.Repository;
using MediatR;

namespace Catalog.Service.Books.Handler
{
    public sealed class BookFindRequestHandler : IRequestHandler<Request.BookFindRequest, Book>
    {
        private readonly ILiquidRepository<Book, string> _booksRepository;

        public BookFindRequestHandler(ILiquidRepository<Book, string> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<Book> Handle(Request.BookFindRequest request, CancellationToken cancellationToken)
        {
            return await _booksRepository.FindByIdAsync(request.Id);
        }
    }
}
