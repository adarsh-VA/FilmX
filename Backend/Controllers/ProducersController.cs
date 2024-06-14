using Assignment_3.Models.DbModels;
using Assignment_3.Models.RequestModels;
using Assignment_3.Services;
using Assignment_3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    
    [ApiController]
    [Route("producers")]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_producerService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_producerService.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProducerRequest producerRequest)
        {
            var id = _producerService.Create(producerRequest);

            return CreatedAtAction("GetById", new { Id = id }, id);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ProducerRequest producerRequest)
        {
            var producer = new Producer
            {
                Id= id,
                Name= producerRequest.Name,
                DOB= producerRequest.DOB,
                Gender= producerRequest.Gender,
                Bio = producerRequest.Bio
            };
            _producerService.Update(producer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _producerService.Delete(id);
            return Ok();
        }
    }
}
