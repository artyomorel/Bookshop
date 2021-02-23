using System;
using AutoMapper;
using Bookshop.Api.Models;
using Bookshop.BussinesLogic.Exceptions;
using Bookshop.BussinesLogic.Services;
using Bookshop.Domain.Interface;
using Bookshop.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bookshop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController: ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService,IMapper mapper, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost]
        public ActionResult<bool> Add(CreateBookRequest createBookRequest)
        {
            try
            {
                var newDomainBook = _mapper.Map<Book>(createBookRequest);
                var result = _bookService.Add(newDomainBook);
                _logger.LogInformation($"Add book with name {newDomainBook.Name}");
                return Ok(result);
            }
            catch (ValidateShowcase ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public ActionResult<GetBookResponse> GetAll()
        {
            _logger.LogInformation("Get All Books");
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
            try
            {
                var result = _bookService.Delete(id);
                _logger.LogWarning($"Book with id {id} was delete ");
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }
        
        [HttpPut]
        public ActionResult<bool> Update(BookDto bookDto)
        {

            try
            {
                var newDomainBook = _mapper.Map<Book>(bookDto);
                var result = _bookService.Update(newDomainBook);
                _logger.LogInformation($"Book with name {newDomainBook.Name} was updated");
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ValidateShowcase ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

   
}