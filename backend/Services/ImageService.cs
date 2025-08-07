using CameraClub2.Models;
using CameraClub2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CameraClub2.Services
{
    public class ImageService : IImageService
    {
        private readonly AppDbContext _context;
        public ImageService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Image>> GetImagesAsync()
        {
            return await _context.Images.Include(i => i.Comments).Include(i => i.Ratings).ToListAsync();
        }

        public async Task<Image?> GetImageAsync(Guid id)
        {
            return await _context.Images.Include(i => i.Comments).Include(i => i.Ratings).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Image> UploadImageAsync(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<bool> DeleteImageAsync(Guid id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null) return false;
            _context.Images.Remove(image);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
