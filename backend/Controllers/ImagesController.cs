using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CameraClub2.Models;

namespace CameraClub2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ImagesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            return await _context.Images.Include(i => i.Comments).Include(i => i.Ratings).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(int id)
        {
            var image = await _context.Images.Include(i => i.Comments).Include(i => i.Ratings).FirstOrDefaultAsync(i => i.ImageID == id);
            if (image == null) return NotFound();
            return image;
        }

        [HttpPost]
        public async Task<ActionResult<Image>> UploadImage(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetImage), new { id = image.ImageID }, image);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null) return NotFound();
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
