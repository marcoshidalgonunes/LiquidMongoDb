using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Liquid.Repository;

namespace Catalog.Service.Books.Handler
{
    public sealed class BookUpdateRequestHandler : BaseBookEditRequestHandler<Request.BookUpdateRequest>
    {
        public BookUpdateRequestHandler(ILiquidRepository<Book, string> booksRepository)
            : base(booksRepository) { }

        public async override Task<Book> Handle(Request.BookUpdateRequest request, CancellationToken cancellationToken)
        {
            var bookIn = await GetValidatedRequest(request);

            var book = await BooksRepository.FindByIdAsync(bookIn.Id);
            if (book != null && book.Id == bookIn.Id)
            {
                await BooksRepository.UpdateAsync(bookIn);
            }

            return book;
        }
    }
}
