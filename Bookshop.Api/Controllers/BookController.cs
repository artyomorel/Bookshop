using Bookshop.BussinesLogic.Services;
using Bookshop.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookshop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController: ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpPost]
        public ActionResult<bool> Add(Book book)
        {
            var result = _bookService.Add(book);
            if (!result)
            {
                return BadRequest(false);
            }
            return Ok(true);
        }
    }
}