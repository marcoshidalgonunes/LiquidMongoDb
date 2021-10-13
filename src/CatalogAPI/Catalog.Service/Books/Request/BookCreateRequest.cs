using Catalog.Service.Entity;

namespace Catalog.Service.Books.Request
{
    public sealed class BookCreateRequest : BaseBookEditRequest
    {
        public BookCreateRequest(Book request) 
            : base(request) { }
    }
}
