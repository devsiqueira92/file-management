namespace FileManagement.Shared.Communication.Responses
{
    public class DownloadFileResponse
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
