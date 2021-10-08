using System;
using System.Collections.Generic;
using Catalog.API.Controllers;
using Catalog.Service.Books;
using Catalog.Service.Entity;
using MediatR;
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
                .Setup(m => m.Send(new BooksRequest(), System.Threading.CancellationToken.None))
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
            var controller = new BookController(_mediatorMock.Object);

            // Act
            var response = await controller.Get();

            // Assert
            var result = Assert.IsType<List<Book>>(response.Value);
            Assert.True(result.Count > 0);
        }
    }
}
