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

        /// <summary>
        /// Gets all competitions in the system.
        /// </summary>
        /// <returns>List of all competitions.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Competition>>> GetCompetitions()
        {
            var competitions = await _competitionService.GetCompetitionsAsync();
            return Ok(competitions);
        }

        /// <summary>
        /// Gets a specific competition by its unique identifier.
        /// </summary>
        /// <param name="id">Competition Guid identifier.</param>
        /// <returns>The competition if found, otherwise NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Competition>> GetCompetition(Guid id)
        {
            var competition = await _competitionService.GetCompetitionAsync(id);
            if (competition == null) return NotFound();
            return Ok(competition);
        }

        /// <summary>
        /// Creates a new competition.
        /// </summary>
        /// <param name="competition">Competition object to create.</param>
        /// <returns>The created competition.</returns>
        [HttpPost]
        public async Task<ActionResult<Competition>> CreateCompetition(Competition competition)
        {
            var created = await _competitionService.CreateCompetitionAsync(competition);
            return CreatedAtAction(nameof(GetCompetition), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing competition.
        /// </summary>
        /// <param name="id">Competition Guid identifier.</param>
        /// <param name="competition">Updated competition object.</param>
        /// <returns>NoContent if successful, otherwise NotFound or BadRequest.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetition(Guid id, Competition competition)
        {
            if (id != competition.Id) return BadRequest();
            var success = await _competitionService.UpdateCompetitionAsync(competition);
            if (!success) return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Deletes a competition by its unique identifier.
        /// </summary>
        /// <param name="id">Competition Guid identifier.</param>
        /// <returns>NoContent if successful, otherwise NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetition(Guid id)
        {
            var success = await _competitionService.DeleteCompetitionAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
