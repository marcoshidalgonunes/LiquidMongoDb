using System.Net;
using System.Threading.Tasks;
using Catalog.Domain.Entity;
using Catalog.Service.Books.Request;
using Catalog.Service.Books.Response;
using Liquid.WebApi.Http.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : LiquidControllerBase
    {
        public BooksController(IMediator mediator) 
            : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<BookQueryResponse>> Get() =>
            await ExecuteAsync(new BookListRequest());

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public async Task<IActionResult> Get(string id) =>
            await ExecuteAsync(new BookFindRequest(id), HttpStatusCode.OK);

        [HttpGet("{criteria},{search}")]
        public async Task<ActionResult<BookQueryResponse>> Get(string criteria, string search) =>
            await ExecuteAsync(new BookSearchRequest(criteria, search));

        [HttpPost]
        public async Task<IActionResult> Create(Book book) =>
            await ExecuteAsync(new BookCreateRequest(book), HttpStatusCode.OK);

        [HttpPut]
        public async Task<IActionResult> Update(Book book) =>
            await ExecuteAsync(new BookUpdateRequest(book), HttpStatusCode.OK);

        [HttpDelete]
        public async Task<IActionResult> Delete(string id) =>
            await ExecuteAsync(new BookDeleteRequest(id), HttpStatusCode.OK);
    }
}
