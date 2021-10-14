using MediatR;

namespace Catalog.Service.Books.Request
{
    public sealed class BookSearchRequest : IRequest<Response.BookQueryResponse>
    {
        public string Criteria { get; private set; }

        public string Value { get; private set; }

        public BookSearchRequest(string criteria, string value)
        {
            Criteria = criteria;
            Value = value;
        }
    }
}
