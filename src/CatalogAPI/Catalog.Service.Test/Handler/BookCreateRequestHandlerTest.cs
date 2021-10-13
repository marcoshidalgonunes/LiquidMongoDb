using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Catalog.Service;
using Catalog.Service.Books;
using Liquid.Repository;
using MediatR;
using MongoDB.Bson;
using Moq;
using Xunit;

namespace Catalog.Service.Test.Handler
{
    public class BookCreateRequestHandlerTest
    {
        private readonly Mock<ILiquidRepository<Entity.Book, string>> _repositoryMock = new();

        [Fact]
        public async void Handle()
        {
            // Arrange
            var book = new Entity.Book
            {
                Author = "Ralph Johnson",
                Name = "Design Patterns",
                Category = "Computers",
                Price = 54.90M
            };
            _repositoryMock
                .Setup(o => o.AddAsync(book));
            var handler = new Books.Handler.BookCreateRequestHandler(_repositoryMock.Object);

            // Act
            var result = await handler.Handle(new Books.Request.BookCreateRequest(book), It.IsAny<CancellationToken>());

            // Assert
            Assert.IsType<Unit>(result);
        }
    }
}
