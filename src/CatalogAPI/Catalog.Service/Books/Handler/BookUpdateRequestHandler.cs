using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Liquid.Repository;
using MediatR;

namespace Catalog.Service.Books.Handler
{
    public sealed class BookUpdateRequestHandler : BaseBookEditRequestHandler<Request.BookUpdateRequest>
    {
        public BookUpdateRequestHandler(ILiquidRepository<Book, string> booksRepository)
            : base(booksRepository) { }

        public async override Task<Unit> Handle(Request.BookUpdateRequest request, CancellationToken cancellationToken)
        {
            var book = await GetValidatedRequest(request);

            await BooksRepository.UpdateAsync(book);

            return new Unit();
        }
    }
}
