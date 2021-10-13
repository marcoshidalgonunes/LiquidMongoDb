using System.Threading;
using System.Threading.Tasks;
using Catalog.Service.Entity;
using Liquid.Repository;
using MongoDB.Bson;

namespace Catalog.Service.Books.Handler
{
    public sealed class BooksListRequestHandler : BaseBooksRequestHandler
    {
        public BooksListRequestHandler(ILiquidRepository<Book, string> booksRepository)
            : base(booksRepository) { }

        public override async Task<Response.BooksResponse> Handle(Request.BooksListRequest request, CancellationToken cancellationToken)
        {
            var items = await BooksRepository.FindAllAsync();

            var response = new Response.BooksResponse(items);

            return response; 
        }
    }
}
