using Microsoft.AspNetCore.Mvc;
using CameraClub2.Models;
using CameraClub2.Interfaces;

namespace CameraClub2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompetitionsController : ControllerBase
    {
        private readonly ICompetitionService _competitionService;
        public CompetitionsController(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Competition>>> GetCompetitions()
        {
            var competitions = await _competitionService.GetCompetitionsAsync();
            return Ok(competitions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Competition>> GetCompetition(int id)
        {
            var competition = await _competitionService.GetCompetitionAsync(id);
            if (competition == null) return NotFound();
            return Ok(competition);
        }

        [HttpPost]
        public async Task<ActionResult<Competition>> CreateCompetition(Competition competition)
        {
            var created = await _competitionService.CreateCompetitionAsync(competition);
            return CreatedAtAction(nameof(GetCompetition), new { id = created.CompetitionID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetition(int id, Competition competition)
        {
            if (id != competition.CompetitionID) return BadRequest();
            var success = await _competitionService.UpdateCompetitionAsync(competition);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetition(int id)
        {
            var success = await _competitionService.DeleteCompetitionAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
