using System.Threading;
using System.Threading.Tasks;
using Catalog.Service.Entity;
using Liquid.Repository;
using MediatR;
using MongoDB.Bson;

namespace Catalog.Service.Books
{
    public sealed class BooksRequestHandler : IRequestHandler<BooksRequest, BooksResponse>
    {
        private readonly ILiquidRepository<Book, ObjectId> _booksRepository;

        public BooksRequestHandler(ILiquidRepository<Book, ObjectId> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<BooksResponse> Handle(BooksRequest request, CancellationToken cancellationToken)
        {
            var items = await _booksRepository.FindAllAsync();

            var response = new BooksResponse(items);

            return response; 
        }
    }
}
