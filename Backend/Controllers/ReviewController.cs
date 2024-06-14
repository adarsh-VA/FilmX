using Assignment_3.Models.DbModels;
using Assignment_3.Models.RequestModels;
using Assignment_3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    
    [ApiController]
    [Route("/movies/{movieId}/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewservice;
        public ReviewController(IReviewService reviewService)
        {
            _reviewservice= reviewService;
        }

        [HttpGet]
        public IActionResult GetByMovie(int movieId)
        {
            return Ok(_reviewservice.GetByMovie(movieId));
        }

        [HttpGet("{reviewId}")]
        public IActionResult GetById(int movieId, int reviewId)
        {
            return Ok(_reviewservice.Get(movieId, reviewId));
        }

        [HttpPut("{reviewId}")]
        public IActionResult Update([FromRoute]int movieId, [FromRoute]int reviewId, [FromBody] ReviewRequest reviewRequest)
        {
            _reviewservice.Update(movieId,new Review {Id=reviewId,Message=reviewRequest.Message,MovieId=movieId });
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromRoute]int movieId, [FromBody]ReviewRequest reviewRequest)
        {
            var id = _reviewservice.Create(movieId,reviewRequest);
            return CreatedAtAction("GetById", new { movieId =movieId,reviewId = id }, reviewRequest);
        }

        [HttpDelete("{reviewId}")]
        public IActionResult Delete([FromRoute]int movieId,int reviewId)
        {
            _reviewservice.Delete(movieId,reviewId);
            return Ok();
        }
    }
}
