using CameraClub2.Models;
using CameraClub2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CameraClub2.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.Include(u => u.ClubMemberships).Include(u => u.EquipmentList).ToListAsync();
        }

        public async Task<User?> GetUserAsync(string id)
        {
            return await _context.Users.Include(u => u.ClubMemberships).Include(u => u.EquipmentList).FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
