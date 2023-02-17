

using Microsoft.AspNetCore.Http;

namespace FileManagement.Domain.Entities
{
    public class FileEntity : BaseEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public double FileSize { get; set; }
        public bool IsDirectory { get; set; } = false;
        public IFormFile FileData { get; set; }
    }
}
