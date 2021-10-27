using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Liquid.Repository;

namespace Catalog.Service.Books.Handler
{
    public sealed class BooksListRequestHandler : BaseBookQueryRequestHandler<Request.BookListRequest>
    {
        public BooksListRequestHandler(ILiquidRepository<Book, string> booksRepository)
            : base(booksRepository) { }
            
        public override async Task<IEnumerable<Book>> Handle(Request.BookListRequest request, CancellationToken cancellationToken)
        {
            var items = await BooksRepository.FindAllAsync();

            return items; 
        }
    }
}
