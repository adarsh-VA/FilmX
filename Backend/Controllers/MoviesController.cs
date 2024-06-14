using Assignment_3.Models.RequestModels;
using Assignment_3.Models.ResponseModels;
using Assignment_3.Repository;
using Assignment_3.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;  
using Firebase.Storage;
using System.Threading.Tasks;
using System;

namespace Assignment1.Controllers
{
    
    [ApiController]
    [Route("movies")]
    public class MoviesController : ControllerBase
    {
        private IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService= movieService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_movieService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_movieService.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody]MovieRequest movieRequest)
        {
            var id = _movieService.Create(movieRequest);
            return CreatedAtAction("GetById", new { Id = id }, id);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody]MovieRequest movieRequest)
        {

            _movieService.Update(id,movieRequest);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return Ok();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file) 
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");
            var task = await new FirebaseStorage("imdb-1785f.appspot.com")
                    .Child("images")
                    .Child(Guid.NewGuid().ToString() + ".jpg")
                    .PutAsync(file.OpenReadStream());
            return Ok(task);
        }

    }
}
