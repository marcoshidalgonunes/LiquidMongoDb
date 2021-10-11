using System.Collections.Generic;
using System.Threading;
using Catalog.API.Controllers;
using Catalog.Service.Books;
using Catalog.Service.Entity;
using MediatR;
using MongoDB.Bson;
using Moq;
using Xunit;

namespace Catalog.API.Test
{
    public class BookControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock = new();

        [Fact]
        public async void Get()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(new BooksRequest(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BooksResponse(new List<Book> {
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
                }));
            var controller = new BooksController(_mediatorMock.Object);

            // Act
            var response = await controller.Get();

            // Assert
            Assert.NotNull(response);
        }
    }
}
