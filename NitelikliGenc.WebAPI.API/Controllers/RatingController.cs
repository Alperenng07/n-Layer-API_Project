using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.WebAPI.Business.Services.Abstract;
using NitelikliGenc.WebAPI.Entities.DTOs;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.API.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class RatingController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IBaseService<Rating> _service;

        public RatingController(IMapper mapper,IBaseService<Rating> service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpPost]

        public async Task<IActionResult> Add(RatingForPostDto ratingForPostDto)
        {
            var rating = _mapper.Map<Rating>(ratingForPostDto);

            if (rating == null)
            {
                return NotFound();
            }
            await _service.AddAsync(rating);
            return Ok(rating);
        }

        [HttpGet]
       public async Task<IActionResult> GetAll()
        {
            var rating= await _service.GetAllAsync();
            if (rating == null)
            {
                NotFound();
            }

            return Ok(rating);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var rating = await _service.GetByIdAsync(id);
            if (rating == null)
            {
                NotFound();
            }

            return  await _service.DeleteAsync(id) ? NoContent() : throw new Exception(); 

           

        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id,RatingForUpdateDto ratingForUpdateDto)
        {
            var stat= await _service.GetByIdAsync(id); if (stat == null) { NotFound(); }


            var rating = _mapper.Map(ratingForUpdateDto,stat);

          await _service.UpdateAsync(rating);
            return Ok(rating);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var rating = await _service.GetByIdAsync(id);
            if (rating == null)
            {
                NotFound();
            }

            return Ok(rating);

        }



    }
}
