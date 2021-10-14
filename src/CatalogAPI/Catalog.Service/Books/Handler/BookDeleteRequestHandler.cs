using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Liquid.Repository;
using MediatR;

namespace Catalog.Service.Books.Handler
{
    public sealed class BookDeleteRequestHandler : IRequestHandler<Request.BookDeleteRequest>
    {
        private readonly ILiquidRepository<Book, string> _booksRepository;

        public BookDeleteRequestHandler(ILiquidRepository<Book, string> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<Unit> Handle(Request.BookDeleteRequest request, CancellationToken cancellationToken)
        {
            await _booksRepository.RemoveByIdAsync(request.Id);

            return new Unit();
        }
    }
}
