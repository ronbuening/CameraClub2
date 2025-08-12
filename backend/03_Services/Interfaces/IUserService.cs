using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CameraClub2.Models;

namespace CameraClub2.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserAsync(Guid id);
    }
}
