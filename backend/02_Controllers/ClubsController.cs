using Microsoft.AspNetCore.Mvc;
using CameraClub2.Models;
using CameraClub2.Interfaces;

namespace CameraClub2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubsController : ControllerBase
    {
        private readonly IClubService _clubService;
        public ClubsController(IClubService clubService)
        {
            _clubService = clubService;
        }

        /// <summary>
        /// Gets all clubs in the system.
        /// </summary>
        /// <returns>List of all clubs.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetClubs()
        {
            var clubs = await _clubService.GetClubsAsync();
            return Ok(clubs);
        }

        /// <summary>
        /// Gets a specific club by its unique identifier.
        /// </summary>
        /// <param name="id">Club Guid identifier.</param>
        /// <returns>The club if found, otherwise NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Club>> GetClub(Guid id)
        {
            var club = await _clubService.GetClubAsync(id);
            if (club == null) return NotFound();
            return Ok(club);
        }

        /// <summary>
        /// Creates a new club.
        /// </summary>
        /// <param name="club">Club object to create.</param>
        /// <returns>The created club.</returns>
        [HttpPost]
        public async Task<ActionResult<Club>> CreateClub(Club club)
        {
            var created = await _clubService.CreateClubAsync(club);
            return CreatedAtAction(nameof(GetClub), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing club.
        /// </summary>
        /// <param name="id">Club Guid identifier.</param>
        /// <param name="club">Updated club object.</param>
        /// <returns>NoContent if successful, otherwise NotFound or BadRequest.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClub(Guid id, Club club)
        {
            if (id != club.Id) return BadRequest();
            var success = await _clubService.UpdateClubAsync(club);
            if (!success) return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Deletes a club by its unique identifier.
        /// </summary>
        /// <param name="id">Club Guid identifier.</param>
        /// <returns>NoContent if successful, otherwise NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub(Guid id)
        {
            var success = await _clubService.DeleteClubAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
