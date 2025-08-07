using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CameraClub2.Models;

namespace CameraClub2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompetitionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CompetitionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Competition>>> GetCompetitions()
        {
            return await _context.Competitions.Include(c => c.Submissions).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Competition>> GetCompetition(int id)
        {
            var competition = await _context.Competitions.Include(c => c.Submissions).FirstOrDefaultAsync(c => c.CompetitionID == id);
            if (competition == null) return NotFound();
            return competition;
        }

        [HttpPost]
        public async Task<ActionResult<Competition>> CreateCompetition(Competition competition)
        {
            _context.Competitions.Add(competition);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCompetition), new { id = competition.CompetitionID }, competition);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetition(int id, Competition competition)
        {
            if (id != competition.CompetitionID) return BadRequest();
            _context.Entry(competition).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetition(int id)
        {
            var competition = await _context.Competitions.FindAsync(id);
            if (competition == null) return NotFound();
            _context.Competitions.Remove(competition);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
