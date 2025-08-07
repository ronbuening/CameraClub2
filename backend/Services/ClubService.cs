using CameraClub2.Models;
using CameraClub2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CameraClub2.Services
{
    public class ClubService : IClubService
    {
        private readonly AppDbContext _context;
        public ClubService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Club>> GetClubsAsync()
        {
            return await _context.Clubs.Include(c => c.Members).ToListAsync();
        }

        public async Task<Club?> GetClubAsync(Guid id)
        {
            return await _context.Clubs.Include(c => c.Members).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Club> CreateClubAsync(Club club)
        {
            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();
            return club;
        }

        public async Task<bool> UpdateClubAsync(Club club)
        {
            _context.Entry(club).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteClubAsync(Guid id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null) return false;
            _context.Clubs.Remove(club);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
