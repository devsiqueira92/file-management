
namespace FileManagement.Shared.Communication.Requests
{
    public class CreateFileRequest
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public double FileSize { get; set; }
    }
}
