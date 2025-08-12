using CameraClub2.Models;
using CameraClub2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CameraClub2.Services
{
    public class RatingService : IRatingService
    {
        private readonly AppDbContext _context;
        public RatingService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all ratings from the database.
        /// </summary>
        public async Task<IEnumerable<Rating>> GetRatingsAsync()
        {
            return await _context.Ratings.ToListAsync();
        }

        /// <summary>
        /// Adds a new rating to the database.
        /// </summary>
        public async Task<Rating> AddRatingAsync(Rating rating)
        {
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
            return rating;
        }
    }
}
