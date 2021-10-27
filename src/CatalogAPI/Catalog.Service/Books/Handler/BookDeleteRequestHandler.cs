using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Liquid.Repository;
using MediatR;

namespace Catalog.Service.Books.Handler
{
    public sealed class BookDeleteRequestHandler : IRequestHandler<Request.BookDeleteRequest, string>
    {
        private readonly ILiquidRepository<Book, string> _booksRepository;

        public BookDeleteRequestHandler(ILiquidRepository<Book, string> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<string> Handle(Request.BookDeleteRequest request, CancellationToken cancellationToken)
        {
            var book = await _booksRepository.FindByIdAsync(request.Id);
            if (book == null)
            {
                return null;
            }

            await _booksRepository.RemoveByIdAsync(request.Id);
            return string.Empty;
        }
    }
}
