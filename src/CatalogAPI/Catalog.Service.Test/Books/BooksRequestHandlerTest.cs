using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Catalog.Service.Books;
using Catalog.Service.Entity;
using Liquid.Repository;
using MediatR;
using MongoDB.Bson;
using Moq;
using Xunit;

namespace Catalog.Service.Test
{
    public class BooksRequestHandlerTest
    {
        private readonly Mock<ILiquidRepository<Book, ObjectId>> _repositoryMock = new();

        [Fact]
        public async void Handle()
        {
            // Arrange
            _repositoryMock
                .Setup(o => o.FindAllAsync())
                .ReturnsAsync(new List<Book> {
                    new Book {
                        Id = new ObjectId("613260743633c438d5250513"),
                        Author = "Ralph Johnson",
                        Name = "Design Patterns",
                        Category = "Computers",
                        Price = 54.90M
                    },
                    new Book {
                        Id = new ObjectId("613260743633c438d5250514"),
                        Author = "Robert C. Martin",
                        Name = "Clean Code",
                        Category = "Computers",
                        Price = 43.15M
                    }
                });
            var handler = new BooksRequestHandler(_repositoryMock.Object);

            // Act
            var result = await handler.Handle(new BooksRequest(), CancellationToken.None);

            // Assert
            Assert.True(result.Response.Any());
        }
    }
}
