using CameraClub2.Models;
using CameraClub2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CameraClub2.Services
{
    public class CompetitionService : ICompetitionService
    {
        private readonly AppDbContext _context;
        public CompetitionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Competition>> GetCompetitionsAsync()
        {
            return await _context.Competitions.Include(c => c.Submissions).ToListAsync();
        }

        public async Task<Competition?> GetCompetitionAsync(int id)
        {
            return await _context.Competitions.Include(c => c.Submissions).FirstOrDefaultAsync(c => c.CompetitionID == id);
        }

        public async Task<Competition> CreateCompetitionAsync(Competition competition)
        {
            _context.Competitions.Add(competition);
            await _context.SaveChangesAsync();
            return competition;
        }

        public async Task<bool> UpdateCompetitionAsync(Competition competition)
        {
            _context.Entry(competition).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCompetitionAsync(int id)
        {
            var competition = await _context.Competitions.FindAsync(id);
            if (competition == null) return false;
            _context.Competitions.Remove(competition);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
