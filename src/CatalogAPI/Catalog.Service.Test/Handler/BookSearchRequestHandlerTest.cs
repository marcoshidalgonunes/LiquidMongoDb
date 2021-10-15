using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Liquid.Repository.Mongo;
using Liquid.Repository.Mongo.Configuration;
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
            var collectionName = "Books";
            var criteria = "Category";
            var search = "Computers";
            var queryExpr = new BsonRegularExpression(new Regex(search, RegexOptions.IgnoreCase));
            var builder = Builders<Book>.Filter;
            var filter = builder.Regex(criteria, queryExpr);

            var cursorMock = new Mock<IAsyncCursor<Book>>();
            cursorMock
                .Setup(_ => _.Current)
                .Returns(new List<Book> {
                    new Book {
                        Id = "613260743633c438d5250513",
                        Author = "Ralph Johnson",
                        Name = "Design Patterns",
                        Category = "Computers",
                        Price = 54.90M
                    }
                });
            cursorMock
                .SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
                .Returns(true)
                .Returns(false);
            cursorMock
                .SetupSequence(_ => _.MoveNextAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(true))
                .Returns(Task.FromResult(false));

            var collectionMock = new Mock<IMongoCollection<Book>>();
            collectionMock
                .Setup(o => o.FindAsync(filter, It.IsAny<FindOptions<Book, Book>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cursorMock.Object);

            _ = _contextMock
                .SetupGet(o => o.Settings).Returns(new MongoEntityOptions { DatabaseName = "BookstoreDb", CollectionName = collectionName, ShardKey = "Id" });

            _ = _contextMock
                .Setup(o => o.Database.GetCollection<Book>(collectionName, null))
                .Returns(collectionMock.Object);

            var repositoryMock = new Mock<MongoRepository<Book, string>>(MockBehavior.Loose, _contextMock.Object);

            var handler = new Books.Handler.BookSearchRequestHandler(repositoryMock.Object);

            // Act
            var result = await handler.Handle(new Books.Request.BookSearchRequest(criteria, search), It.IsAny<CancellationToken>());

            // Assert
            Assert.NotNull(result);
        }
    }
}
