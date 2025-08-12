using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CameraClub2.Models;

namespace CameraClub2.Interfaces
{
    public interface IImageService
    {
        Task<IEnumerable<Image>> GetImagesAsync();
        Task<Image?> GetImageAsync(Guid id);
        Task<Image> UploadImageAsync(Image image);
        Task<bool> DeleteImageAsync(Guid id);
    }
}
