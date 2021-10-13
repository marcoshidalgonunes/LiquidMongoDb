using System.Threading;
using System.Threading.Tasks;
using Liquid.Repository;
using MediatR;

namespace Catalog.Service.Books.Handler
{
    public abstract class BaseBookEditRequestHandler<TRequest> : IRequestHandler<TRequest>
        where TRequest: Request.BaseBookEditRequest
    {
        protected readonly ILiquidRepository<Entity.Book, string> BooksRepository;

        public BaseBookEditRequestHandler(ILiquidRepository<Entity.Book, string> booksRepository)
        {
            BooksRepository = booksRepository;
        }

        public abstract Task<Unit> Handle(TRequest request, CancellationToken cancellationToken);

        protected async Task<Entity.Book> GetValidatedRequest(TRequest request)
        {
            var book = request.Request;

            var validator = new Validator.BookValidator();
            var validatorResult = await validator.ValidateAsync(book);

            if (validatorResult.Errors.Count > 0)
                throw new Exceptions.LiquidValidationException(validatorResult);

            return book;
        }
    }
}
