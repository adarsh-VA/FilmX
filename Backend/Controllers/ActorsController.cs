using Assignment_3.Models.DbModels;
using Assignment_3.Models.RequestModels;
using Assignment_3.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    
    [ApiController]
    [Route("actors")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_actorService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_actorService.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] ActorRequest actorRequest)
        {
            var id = _actorService.Create(actorRequest);

            return CreatedAtAction("GetById", new {Id = id},id);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id,[FromBody]ActorRequest actorRequest)
        {
            var actor = new Actor { 
                Id= id,
                Name= actorRequest.Name,
                Bio = actorRequest.Bio,
                DOB= actorRequest.DOB,
                Gender = actorRequest.Gender
            };

            _actorService.Update(actor);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _actorService.Delete(id);
            return Ok();
        }
    }
}
