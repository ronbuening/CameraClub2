using System.Collections.Generic;
using System.Threading.Tasks;
using CameraClub2.Models;

namespace CameraClub2.Interfaces
{
    public interface ICompetitionService
    {
        Task<IEnumerable<Competition>> GetCompetitionsAsync();
        Task<Competition?> GetCompetitionAsync(int id);
        Task<Competition> CreateCompetitionAsync(Competition competition);
        Task<bool> UpdateCompetitionAsync(Competition competition);
        Task<bool> DeleteCompetitionAsync(int id);
    }
}
