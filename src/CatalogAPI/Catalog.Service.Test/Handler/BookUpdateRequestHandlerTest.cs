using System.Threading;
using Catalog.Domain.Entity;
using Liquid.Repository;
using MediatR;
using Moq;
using Xunit;

namespace Catalog.Service.Test.Handler
{
    public class BookUpdateRequestHandlerTest
    {
        private readonly Mock<ILiquidRepository<Book, string>> _repositoryMock = new();

        [Fact]
        public async void Handle()
        {
            // Arrange
            var book = new Book
            {
                Id = "613260743633c438d5250513",
                Author = "Ralph Johnson",
                Name = "Design Patterns",
                Category = "Computers",
                Price = 27.45M
            };
            _repositoryMock
                .Setup(o => o.AddAsync(book));
            var handler = new Books.Handler.BookUpdateRequestHandler(_repositoryMock.Object);

            // Act
            var result = await handler.Handle(new Books.Request.BookUpdateRequest(book), It.IsAny<CancellationToken>());

            // Assert
            Assert.IsType<Unit>(result);
        }
    }
}
