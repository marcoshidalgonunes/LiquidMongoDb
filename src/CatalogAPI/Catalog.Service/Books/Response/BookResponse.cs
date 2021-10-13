namespace Catalog.Service.Books.Response
{
    public sealed class BookResponse
    {
        public Entity.Book Response { get; private set; }

        public BookResponse(Entity.Book response)
        {
            Response = response;
        }
    }
}
