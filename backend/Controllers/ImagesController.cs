using Microsoft.AspNetCore.Mvc;
using CameraClub2.Models;
using CameraClub2.Interfaces;

namespace CameraClub2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            var images = await _imageService.GetImagesAsync();
            return Ok(images);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(int id)
        {
            var image = await _imageService.GetImageAsync(id);
            if (image == null) return NotFound();
            return Ok(image);
        }

        [HttpPost]
        public async Task<ActionResult<Image>> UploadImage(Image image)
        {
            var uploaded = await _imageService.UploadImageAsync(image);
            return CreatedAtAction(nameof(GetImage), new { id = uploaded.ImageID }, uploaded);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var success = await _imageService.DeleteImageAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
