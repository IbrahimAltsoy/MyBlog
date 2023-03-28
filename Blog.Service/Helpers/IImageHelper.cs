using Blog.Entity.DTOS.Images;
using Blog.Entity.Enums;
using Microsoft.AspNetCore.Http;

namespace Blog.Service.Helpers
{
    public interface IImageHelper
    {
        Task<ImageUploadDTO> Upload(string name, IFormFile imageFile,ImageType imageType, string folderName=null);
        void Delete(string imageName);
    }
}
