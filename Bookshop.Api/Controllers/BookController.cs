using AutoMapper;
using Bookshop.Api.Models;
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
        private readonly IMapper _mapper;

        public BookController(IBookService bookService,IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }


        [HttpPost]
        public ActionResult<bool> Add(CreateBookRequest createBookRequest)
        {
            var newDomainBook = _mapper.Map<Book>(createBookRequest);
            var result = _bookService.Add(newDomainBook);
            if (!result)
            {
                return BadRequest(false);
            }
            return Ok(true);
        }
    }
}