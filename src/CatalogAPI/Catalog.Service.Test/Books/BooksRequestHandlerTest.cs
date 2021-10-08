using System.Collections.Generic;
using System.Threading;
using Catalog.Service.Books;
using Catalog.Service.Entity;
using Liquid.Repository;
using MediatR;
using Moq;
using Xunit;

namespace Catalog.Service.Test
{
    public class BooksRequestHandlerTest
    {
        private readonly Mock<ILiquidRepository<Book, string>> _repositoryMock = new();
        private readonly Mock<IRequest<List<Book>>> _request = new();

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
                        BookName = "Design Patterns",
                        Category = "Computers",
                        Price = 54.90M
                    },
                    new Book {
                        Id = "613260743633c438d5250514",
                        Author = "Robert C. Martin",
                        BookName = "Clean Code",
                        Category = "Computers",
                        Price = 43.15M
                    }
                });
            var handler = new BooksRequestHandler(_repositoryMock.Object);

            // Act
            var result = await handler.Handle(_request.Object, CancellationToken.None);

            // Assert
            Assert.True(result.Count > 0);
        }
    }
}
