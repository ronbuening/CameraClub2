using System.Collections.Generic;
using System.Threading.Tasks;
using CameraClub2.Models;

namespace CameraClub2.Interfaces
{
    public interface IClubService
    {
        Task<IEnumerable<Club>> GetClubsAsync();
        Task<Club?> GetClubAsync(int id);
        Task<Club> CreateClubAsync(Club club);
        Task<bool> UpdateClubAsync(Club club);
        Task<bool> DeleteClubAsync(int id);
    }
}
