using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Liquid.Repository;
using MediatR;

namespace Catalog.Service.Books.Handler
{
    public sealed class BooksListRequestHandler : IRequestHandler<Request.BookListRequest, IEnumerable<Book>>
    {
        private readonly ILiquidRepository<Book, string> _booksRepository;

        public BooksListRequestHandler(ILiquidRepository<Book, string> booksRepository)
        {
            _booksRepository = booksRepository;
        }
            
        public async Task<IEnumerable<Book>> Handle(Request.BookListRequest request, CancellationToken cancellationToken)
        {
            var items = await _booksRepository.FindAllAsync();

            return items; 
        }
    }
}
