using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CameraClub2.Models;

namespace CameraClub2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.Include(u => u.ClubMemberships).Include(u => u.EquipmentList).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _context.Users.Include(u => u.ClubMemberships).Include(u => u.EquipmentList).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return NotFound();
            return user;
        }
    }
}
