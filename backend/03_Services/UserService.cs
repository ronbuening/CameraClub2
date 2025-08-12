using CameraClub2.Models;
using CameraClub2.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace CameraClub2.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        const int keySize = 64;
        const int iterations = 250000;
        public async Task<ActionResult<string?>> InitHashPassword(Guid userId, string _rawPassword)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(keySize);
            await _userStorage.StoreSeasoningAsync(userId, salt);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(_rawPassword),
                salt,
                iterations,
                HashAlgorithmName.SHA512,
                keySize
            );
            return Convert.ToHexString(hash);
        }
        public async Task<string?> HashPassword(Guid userId, string _rawPassword)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(keySize);
            await _userStorage.UpdateSeasoningAsync(userId, salt);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(_rawPassword),
                salt,
                iterations,
                HashAlgorithmName.SHA512,
                keySize
            );
            return Convert.ToHexString(hash);
        }
        public async Task<bool> VerifyPassword(User user, string _rawPassword, string _hashedPassword)
        {
            string salt = await _userStorage.GetSeasoningAsync(user.UserId);
            if (salt == null) return false;

            var comparisonHash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(_rawPassword),
                Convert.FromHexString(salt),
                iterations,
                HashAlgorithmName.SHA512,
                keySize
            );
            return CryptographicOperations.FixedTimeEquals(comparisonHash, Convert.FromHexString(user.Password));
        }
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<bool> UserExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
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
            return await _context.Users.Include(u => u.ClubMemberships).Include(u => u.EquipmentList).FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}
