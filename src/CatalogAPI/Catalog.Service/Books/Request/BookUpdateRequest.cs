using Catalog.Domain.Entity;

namespace Catalog.Service.Books.Request
{
    public sealed class BookUpdateRequest : BaseBookEditRequest
    {
        public BookUpdateRequest(Book request)
            : base(request) { }
    }
}
