using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Liquid.Repository;
using Liquid.Repository.Mongo;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Service.Books.Handler
{
    public sealed class BookSearchRequestHandler : IRequestHandler<Request.BookSearchRequest, Response.BookQueryResponse>
    {
        private readonly IMongoDataContext<Book> _context;

        public BookSearchRequestHandler(ILiquidRepository<Book, string> booksRepository)
        {
            var repository = booksRepository;
            _context = repository.DataContext as IMongoDataContext<Book>;
        }

        public async Task<Response.BookQueryResponse> Handle(Request.BookSearchRequest request, CancellationToken cancellationToken)
        {
            var queryExpr = new BsonRegularExpression(new Regex(request.Value, RegexOptions.IgnoreCase));
            var builder = Builders<Book>.Filter;
            var filter = builder.Regex(request.Criteria, queryExpr);

            var collection = _context.Database.GetCollection<Book>(_context.Settings.CollectionName);
            var items = await collection.FindAsync<Book>(filter, null, cancellationToken);

            var response = new Response.BookQueryResponse(await items.ToListAsync(cancellationToken));
            return response;
        }
    }
}
