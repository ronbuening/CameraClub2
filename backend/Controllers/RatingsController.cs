using Microsoft.AspNetCore.Mvc;
using CameraClub2.Models;
using CameraClub2.Interfaces;

namespace CameraClub2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        /// <summary>
        /// Gets all ratings in the system.
        /// </summary>
        /// <returns>List of all ratings.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRatings()
        {
            var ratings = await _ratingService.GetRatingsAsync();
            return Ok(ratings);
        }

        /// <summary>
        /// Adds a new rating to a submission.
        /// </summary>
        /// <param name="rating">Rating object to add.</param>
        /// <returns>The created rating.</returns>
        [HttpPost]
        public async Task<ActionResult<Rating>> AddRating(Rating rating)
        {
            var added = await _ratingService.AddRatingAsync(rating);
            return CreatedAtAction(nameof(GetRatings), new { id = added.Id }, added);
        }
    }
}
