using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.WebAPI.Business.Services.Abstract;
using NitelikliGenc.WebAPI.Entities.DTOs;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<Tag> _service;

        public TagController(IMapper mapper,IBaseService<Tag> service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var tag= await _service.GetAllAsync();
            return Ok(tag);
        }


        [HttpPost]
        public async Task<IActionResult> Add(TagForPostDto tagForPostDto)
        {
            var tag = _mapper.Map<Tag>(tagForPostDto);
            await _service.AddAsync(tag);

            return Ok(tag);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            
            var order = _service.GetByIdAsync(id);

            if (order == null) {
                NotFound();
            }
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id,TagForUpdateDto tagForUpdateDto)
        {
            var tag = _service.GetByIdAsync(id);
            if (tag== null)
            {
                return NotFound();
            }

            var stat = await _mapper.Map(tagForUpdateDto, tag);
            _service.UpdateAsync(stat);

            return Ok(stat);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            var tag = _service.GetByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }
    }
}
