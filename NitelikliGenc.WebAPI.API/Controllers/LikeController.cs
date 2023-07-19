using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.WebAPI.Business.Services.Abstract;
using NitelikliGenc.WebAPI.Entities.DTOs;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LikeController : ControllerBase
    {
        private readonly IBaseService<Like> _service;
        private readonly IMapper _mapper;

        public LikeController(IBaseService<Like> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> Get() {

            return Ok(await _service.GetAllAsync());
        }
       


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            return Ok(await _service.GetByIdAsync(id));
        }


        [HttpPost]
        public async Task<IActionResult> Add(LikedForDto likedForDto)
        {
           var liked = _mapper.Map<Like>(likedForDto);

            if (liked == null)
            {
                return NotFound();
            }

            await _service.AddAsync(liked);
            return Ok(liked);
        }

        [HttpPut]
        public async Task<IActionResult> Update(LikedForUpdateDto likedForUpdateDto,Guid id)
        {
            var stat = await _service.GetByIdAsync(id);
            if (stat == null)
            {
                return NotFound();
            }

            var liked = _mapper.Map(likedForUpdateDto,stat);

           

            await _service.UpdateAsync(liked);
            return Ok(liked);


        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var stat = await _service.GetByIdAsync(id);
            if (stat == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return Ok();
        }

      
    }
}
