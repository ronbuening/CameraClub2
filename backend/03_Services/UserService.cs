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

        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.Include(u => u.ClubMemberships).Include(u => u.EquipmentList).ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific user by their Guid identifier.
        /// </summary>
        public async Task<User?> GetUserAsync(Guid id)
        {
            return await _context.Users.Include(u => u.ClubMemberships).Include(u => u.EquipmentList).FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<string> HashPassword(string password)
        {
            // Implement password hashing logic here
            return await password; // Placeholder, replace with actual hashing
        }
    }
}
