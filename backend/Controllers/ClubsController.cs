using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CameraClub2.Models;

namespace CameraClub2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClubsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetClubs()
        {
            return await _context.Clubs.Include(c => c.Members).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Club>> GetClub(int id)
        {
            var club = await _context.Clubs.Include(c => c.Members).FirstOrDefaultAsync(c => c.ClubID == id);
            if (club == null) return NotFound();
            return club;
        }

        [HttpPost]
        public async Task<ActionResult<Club>> CreateClub(Club club)
        {
            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetClub), new { id = club.ClubID }, club);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClub(int id, Club club)
        {
            if (id != club.ClubID) return BadRequest();
            _context.Entry(club).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null) return NotFound();
            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
