

using Microsoft.AspNetCore.Http;

namespace FileManagement.Shared.Communication.Requests
{
    public class UploadFileRequest
    {
        public IFormFile FileData { get; set; }
        public string FileName { get; set; }
    }
}
