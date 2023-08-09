using Microsoft.AspNetCore.Http;

namespace edTechSpark.APIs.Helpers
{
    public interface IFileHelper
    {
        void DeleteFile(string imageUrl);
        string UploadFile(IFormFile file);
    }
}
