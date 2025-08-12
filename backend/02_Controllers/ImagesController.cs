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

        /// <summary>
        /// Gets all images in the system.
        /// </summary>
        /// <returns>List of all images.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            var images = await _imageService.GetImagesAsync();
            return Ok(images);
        }

        /// <summary>
        /// Gets a specific image by its unique identifier.
        /// </summary>
        /// <param name="id">Image Guid identifier.</param>
        /// <returns>The image if found, otherwise NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(Guid id)
        {
            var image = await _imageService.GetImageAsync(id);
            if (image == null) return NotFound();
            return Ok(image);
        }

        /// <summary>
        /// Uploads a new image.
        /// </summary>
        /// <param name="image">Image object to upload.</param>
        /// <returns>The uploaded image.</returns>
        [HttpPost]
        public async Task<ActionResult<Image>> UploadImage(Image image)
        {
            var uploaded = await _imageService.UploadImageAsync(image);
            return CreatedAtAction(nameof(GetImage), new { id = uploaded.Id }, uploaded);
        }

        /// <summary>
        /// Deletes an image by its unique identifier.
        /// </summary>
        /// <param name="id">Image Guid identifier.</param>
        /// <returns>NoContent if successful, otherwise NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            var success = await _imageService.DeleteImageAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
