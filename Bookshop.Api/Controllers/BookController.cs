using AutoMapper;
using Bookshop.Api.Models;
using Bookshop.BussinesLogic.Services;
using Bookshop.Domain.Interface;
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

        [HttpGet]
        public ActionResult<GetBookResponse> GetAll()
        {
            var domainBooks = _bookService.GetAll();
            return new GetBookResponse
            {
                Books = _mapper.Map<BookDto[]>(domainBooks)
            };
        }

        [HttpGet("{id}")]
        public ActionResult<BookDto> Get(int id)
        {
            var domainBook = _bookService.GetById(id);
            return _mapper.Map<BookDto>(domainBook);
        }
        
        

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
          var result = _bookService.Delete(id);
          return result? Ok(true): BadRequest("Not found");
        }
        
        [HttpPut]
        public ActionResult<bool> Update(BookDto bookDto)
        {
            var newDomainBook = _mapper.Map<Book>(bookDto);
            var result = _bookService.Update(newDomainBook);
            return result? Ok(true): BadRequest("Not found");
        }
    }

   
}