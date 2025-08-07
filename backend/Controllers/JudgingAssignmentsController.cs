using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CameraClub2.Models;

namespace CameraClub2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JudgingAssignmentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public JudgingAssignmentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JudgingAssignment>>> GetJudgingAssignments()
        {
            return await _context.JudgingAssignments.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<JudgingAssignment>> AddJudgingAssignment(JudgingAssignment assignment)
        {
            _context.JudgingAssignments.Add(assignment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetJudgingAssignments), new { id = assignment.JudgingAssignmentID }, assignment);
        }
    }
}
