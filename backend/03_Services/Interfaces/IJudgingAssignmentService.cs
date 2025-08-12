using System.Collections.Generic;
using System.Threading.Tasks;
using CameraClub2.Models;

namespace CameraClub2.Interfaces
{
    public interface IJudgingAssignmentService
    {
        Task<IEnumerable<JudgingAssignment>> GetJudgingAssignmentsAsync();
        Task<JudgingAssignment> AddJudgingAssignmentAsync(JudgingAssignment assignment);
    }
}
