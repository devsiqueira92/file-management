using FileManagement.Domain.Entities;

namespace FileManagement.Domain.RepositoryInterface
{
    public interface IFileRepository : IBaseRepository<FileEntity>
    {
        Task<List<string>> ReadFisicalFiles(FileEntity file);
        Task<bool> UploadFile(FileEntity file);
        Task<byte[]> DownloadFile(FileEntity file);
        Task MoveFile(FileEntity file, string destinationPath);
    }
}
