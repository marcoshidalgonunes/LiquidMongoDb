using System.Threading;
using System.Threading.Tasks;
using Liquid.Repository;
using MediatR;

namespace Catalog.Service.Books.Handler
{
    public sealed class BookCreateRequestHandler : BaseBookEditRequestHandler<Request.BookCreateRequest>
    {
        public BookCreateRequestHandler(ILiquidRepository<Entity.Book, string> booksRepository)
            : base(booksRepository) { }

        public async override Task<Unit> Handle(Request.BookCreateRequest request, CancellationToken cancellationToken)
        {
            var book = await GetValidatedRequest(request);

            await BooksRepository.AddAsync(book);

            return new Unit();
        }
    }
}
