using System.Collections;
using System.Collections.Generic;
using Bookshop.Domain.Interface;
using Bookshop.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookshop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowcaseController: ControllerBase
    {
        private readonly IShowcaseService _service;

        public ShowcaseController(IShowcaseService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<ICollection<Book>> GetBooksFromShowcase()
        {
            return Ok();
        }
        
        [HttpPost]
        public ActionResult<bool> Add(Showcase showcase)
        {
            return Ok(_service.Add(showcase));
        }
    }
}