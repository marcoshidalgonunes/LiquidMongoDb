using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Catalog.Domain.Validation;
using Liquid.Repository;
using MediatR;

namespace Catalog.Service.Books.Handler
{
    public abstract class BaseBookEditRequestHandler<TRequest> : IRequestHandler<TRequest, Book>
        where TRequest: Request.BaseBookEditRequest
    {
        protected readonly ILiquidRepository<Book, string> BooksRepository;

        public BaseBookEditRequestHandler(ILiquidRepository<Book, string> booksRepository)
        {
            BooksRepository = booksRepository;
        }

        public abstract Task<Book> Handle(TRequest request, CancellationToken cancellationToken);

        protected async Task<Book> GetValidatedRequest(TRequest request)
        {
            var book = request.Request;

            var validator = new BookValidator();
            var validatorResult = await validator.ValidateAsync(book);

            if (validatorResult.Errors.Count > 0)
                throw new Exceptions.LiquidValidationException(validatorResult);

            return book;
        }
    }
}
