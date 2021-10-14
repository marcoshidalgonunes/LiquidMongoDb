using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Catalog.Domain.Entity;
using Liquid.Repository.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace Catalog.Service.Test.Handler
{
    public class BooksSearchRequestHandlerTest : IDisposable
    {
        private readonly Mock<IMongoDataContext<Book>> _contextMock = new();

        public void Dispose()
        {
            _contextMock.Object.Dispose();
        }

        [Fact]
        public async void Handle()
        {
            // Arrange
            var criteria = "Category";
            var search = "Computers";
            var queryExpr = new BsonRegularExpression(new Regex(search, RegexOptions.IgnoreCase));
            var builder = Builders<Book>.Filter;
            var filter = builder.Regex(criteria, queryExpr);

            var repositoryMock = new Mock<MongoRepository<Book, string>>(_contextMock.Object);

            //_contextMock
            //    .Setup(o => o.Database.GetCollection<Book>("Books").FindAsync<Book>(filter, cancellationToken: It.IsAny<CancellationToken>))
            //    .ReturnsAsync(new List<Book> {
            //        new Book {
            //            Id = "613260743633c438d5250513",
            //            Author = "Ralph Johnson",
            //            Name = "Design Patterns",
            //            Category = "Computers",
            //            Price = 54.90M
            //        },
            //        new Book {
            //            Id = "613260743633c438d5250514",
            //            Author = "Robert C. Martin",
            //            Name = "Clean Code",
            //            Category = "Programming",
            //            Price = 43.15M
            //        }
            //    });
            var handler = new Books.Handler.BookSearchRequestHandler(repositoryMock.Object);

            // Act
            var result = await handler.Handle(new Books.Request.BookSearchRequest(criteria, search), It.IsAny<CancellationToken>());

            // Assert
            Assert.True(result.Response.Any());
        }
    }
}
