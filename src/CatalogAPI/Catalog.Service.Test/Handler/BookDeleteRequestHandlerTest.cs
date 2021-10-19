using System.Threading;
using Catalog.Domain.Entity;
using Liquid.Repository;
using Moq;
using Xunit;

namespace Catalog.Service.Test.Handler
{
    public class BookDeleteRequestHandlerTest
    {
        private readonly Mock<ILiquidRepository<Book, string>> _repositoryMock = new();

        [Fact]
        public async void Handle()
        {
            // Arrange
            var id = "613260743633c438d5250513";
            _repositoryMock
                .Setup(o => o.FindByIdAsync(id))
                .ReturnsAsync(new Book
                {
                    Id = id,
                    Author = "Ralph Johnson",
                    Name = "Design Patterns",
                    Category = "Computers",
                    Price = 54.90M
                });
            _repositoryMock
                .Setup(o => o.RemoveByIdAsync(id));
            var handler = new Books.Handler.BookDeleteRequestHandler(_repositoryMock.Object);

            // Act
            var result = await handler.Handle(new Books.Request.BookDeleteRequest(id), It.IsAny<CancellationToken>());

            // Assert
            Assert.IsType<string>(result);
        }

        [Fact]
        public async void HandleNotFound()
        {
            // Arrange
            var id = "613260743633c438d5250513";
            Book book = null;

            _repositoryMock
                .Setup(o => o.FindByIdAsync(id))
                .ReturnsAsync(book);

            var handler = new Books.Handler.BookDeleteRequestHandler(_repositoryMock.Object);

            // Act
            var result = await handler.Handle(new Books.Request.BookDeleteRequest(id), It.IsAny<CancellationToken>());

            // Assert
            Assert.Null(result);
        }
    }
}
