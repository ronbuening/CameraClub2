using System.Collections.Generic;
using System.Threading.Tasks;
using CameraClub2.Models;

namespace CameraClub2.Interfaces
{
    public interface IRatingService
    {
        Task<IEnumerable<Rating>> GetRatingsAsync();
        Task<Rating> AddRatingAsync(Rating rating);
    }
}
