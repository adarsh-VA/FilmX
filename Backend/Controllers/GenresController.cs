using Assignment_3.Models.DbModels;
using Assignment_3.Models.RequestModels;
using Assignment_3.Services;
using Assignment_3.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Assignment1.Controllers
{
    [ApiController]

    [Route("genres")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;    
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_genreService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_genreService.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] GenreRequest genreRequest)
        {
            var id = _genreService.Create(genreRequest);

            return CreatedAtAction("GetById", new { Id = id }, id);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody]GenreRequest genreRequest)
        {
            _genreService.Update(new Genre { Id = id, Name = genreRequest.Name });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _genreService.Delete(id);
            return Ok();
        }
    }
}
