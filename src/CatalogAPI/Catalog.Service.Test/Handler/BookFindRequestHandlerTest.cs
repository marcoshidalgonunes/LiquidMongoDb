using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Catalog.Service;
using Catalog.Service.Books;
using Liquid.Repository;
using MongoDB.Bson;
using Moq;
using Xunit;

namespace Catalog.Service.Test.Handler
{
    public class BookFindRequestHandlerTest
    {
        private readonly Mock<ILiquidRepository<Entity.Book, string>> _repositoryMock = new();

        [Fact]
        public async void Handle()
        {
            // Arrange
            var id = "613260743633c438d5250513";
            _repositoryMock
                .Setup(o => o.FindByIdAsync(id))
                .ReturnsAsync(new Entity.Book {
                     Id = id,
                     Author = "Ralph Johnson",
                     Name = "Design Patterns",
                     Category = "Computers",
                     Price = 54.90M
                });
            var handler = new Books.Handler.BookFindRequestHandler(_repositoryMock.Object);

            // Act
            var result = await handler.Handle(new Books.Request.BookFindRequest(id), It.IsAny<CancellationToken>());

            // Assert
            Assert.NotNull(result?.Response);
        }
    }
}
