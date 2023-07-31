using Microsoft.AspNetCore.Http;
using StorageManager;

namespace Infrastructure.Web.Helpers
{
    public class MediaHelper
    {
        private readonly IStorageService _storageService;

        public MediaHelper(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task<string> SaveFile(IFormFile file, string path)
        {
            using var fileMs = new MemoryStream();
            await file.CopyToAsync(fileMs);
            var fileBytes = fileMs.ToArray();
            var fileUrl = await _storageService.Upload(path, file.ContentType, fileBytes);

            return fileUrl;
        }
    }
}
