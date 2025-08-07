using System.Collections.Generic;
using System.Threading.Tasks;
using CameraClub2.Models;

namespace CameraClub2.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentsAsync();
        Task<Comment> AddCommentAsync(Comment comment);
    }
}
