using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Catalog.Service.Books.Request;
using Liquid.Repository;

namespace Catalog.Service.Books.Handler
{
    public sealed class BooksListRequestHandler : BaseBookQueryRequestHandler<BooksListRequest>
    {
        public BooksListRequestHandler(ILiquidRepository<Book, string> booksRepository)
            : base(booksRepository) { }

        public override async Task<Response.BookQueryResponse> Handle(Request.BooksListRequest request, CancellationToken cancellationToken)
        {
            var items = await BooksRepository.FindAllAsync();

            var response = new Response.BookQueryResponse(items);

            return response; 
        }
    }
}
