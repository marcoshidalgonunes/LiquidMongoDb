using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Catalog.Domain.Entity;
using Liquid.Repository;
using Moq;
using Xunit;

namespace Catalog.Service.Test.Handler
{
    public class BooksListRequestHandlerTest
    {
        private readonly Mock<ILiquidRepository<Book, string>> _repositoryMock = new();

        [Fact]
        public async void Handle()
        {
            // Arrange
            _repositoryMock
                .Setup(o => o.FindAllAsync())
                .ReturnsAsync(new List<Book> {
                    new Book {
                        Id = "613260743633c438d5250513",
                        Author = "Ralph Johnson",
                        Name = "Design Patterns",
                        Category = "Computers",
                        Price = 54.90M
                    },
                    new Book {
                        Id = "613260743633c438d5250514",
                        Author = "Robert C. Martin",
                        Name = "Clean Code",
                        Category = "Computers",
                        Price = 43.15M
                    }
                });

            var handler = new Books.Handler.BooksListRequestHandler(_repositoryMock.Object);

            // Act
            var result = await handler.Handle(new Books.Request.BookListRequest(),It.IsAny<CancellationToken>());

            // Assert
            Assert.True(result.Content.Any());
        }
    }
}
