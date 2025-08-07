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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetClubs()
        {
            var clubs = await _clubService.GetClubsAsync();
            return Ok(clubs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Club>> GetClub(int id)
        {
            var club = await _clubService.GetClubAsync(id);
            if (club == null) return NotFound();
            return Ok(club);
        }

        [HttpPost]
        public async Task<ActionResult<Club>> CreateClub(Club club)
        {
            var created = await _clubService.CreateClubAsync(club);
            return CreatedAtAction(nameof(GetClub), new { id = created.ClubID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClub(int id, Club club)
        {
            if (id != club.ClubID) return BadRequest();
            var success = await _clubService.UpdateClubAsync(club);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var success = await _clubService.DeleteClubAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
