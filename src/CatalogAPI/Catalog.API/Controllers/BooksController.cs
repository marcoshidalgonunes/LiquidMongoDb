using System.Threading.Tasks;
using Catalog.Service.Books;
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
        public async Task<ActionResult<BooksResponse>> Get() =>
            await ExecuteAsync(new BooksRequest());
    }
}
