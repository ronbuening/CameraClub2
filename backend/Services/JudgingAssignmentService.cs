using CameraClub2.Models;
using CameraClub2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CameraClub2.Services
{
    public class JudgingAssignmentService : IJudgingAssignmentService
    {
        private readonly AppDbContext _context;
        public JudgingAssignmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JudgingAssignment>> GetJudgingAssignmentsAsync()
        {
            return await _context.JudgingAssignments.ToListAsync();
        }

        public async Task<JudgingAssignment> AddJudgingAssignmentAsync(JudgingAssignment assignment)
        {
            _context.JudgingAssignments.Add(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }
    }
}
