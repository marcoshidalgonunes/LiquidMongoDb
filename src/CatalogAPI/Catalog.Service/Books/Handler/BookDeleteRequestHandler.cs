using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Catalog.Service.Books.Request;
using Liquid.Repository;
using MediatR;

namespace Catalog.Service.Books.Handler
{
    public sealed class BookDeleteRequestHandler : IRequestHandler<Request.BookDeleteRequest, Book>
    {
        private readonly ILiquidRepository<Book, string> _booksRepository;

        public BookDeleteRequestHandler(ILiquidRepository<Book, string> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<Book> Handle(Request.BookDeleteRequest request, CancellationToken cancellationToken)
        {
            var book = await _booksRepository.FindByIdAsync(request.Id);
            if (book != null)
            {
                await _booksRepository.RemoveByIdAsync(request.Id);
            }

            return book;
        }
    }
}
