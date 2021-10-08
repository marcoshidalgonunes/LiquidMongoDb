using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Service.Books;
using Catalog.Service.Entity;
using Liquid.WebApi.Http.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : LiquidControllerBase
    {
        public BookController(IMediator mediator) 
            : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get() =>
            await ExecuteAsync(new BooksRequest());
    }
}
