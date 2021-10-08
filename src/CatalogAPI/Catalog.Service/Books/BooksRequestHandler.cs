using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Service.Entity;
using Liquid.Repository;
using MediatR;

namespace Catalog.Service.Books
{
    public sealed class BooksRequestHandler : IRequestHandler<IRequest<List<Book>>, List<Book>>
    {
        private readonly ILiquidRepository<Book, string> _booksRepository;

        public BooksRequestHandler(ILiquidRepository<Book, string> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<List<Book>> Handle(IRequest<List<Book>> request, CancellationToken cancellationToken)
        {
            var items = await _booksRepository.FindAllAsync();

            return items.ToList(); ;
        }
    }
}
