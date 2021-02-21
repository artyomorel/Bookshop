using AutoMapper;
using Bookshop.Api.Models;
using Bookshop.BussinesLogic.Exceptions;
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
        private readonly IMapper _mapper;

        public ShowcaseController(IShowcaseService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        
        [HttpGet]
        public ActionResult<GetShowcasesResponse> GetAll()
        {
            var showcases = _service.GetAll();
            
            return Ok(new GetShowcasesResponse
            {
                ShowcaseDto = _mapper.Map<ShowcaseDto[]>(showcases)
            });
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                var result = _service.Delete(id);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpPut]
        public ActionResult<bool> Update(ShowcaseDto showcaseDto)
        {
            try
            {
                var showcaseModel = _mapper.Map<Showcase>(showcaseDto);
                var result = _service.Update(showcaseModel);
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
        
        [HttpPost]
        public ActionResult<bool> Add(CreateShowcaseRequest showcase)
        {
            var newShowcase = _mapper.Map<Showcase>(showcase);
            return Ok(_service.Add(newShowcase));
        }
    }
}