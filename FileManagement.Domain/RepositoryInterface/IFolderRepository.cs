using FileManagement.Domain.Entities;

namespace FileManagement.Domain.RepositoryInterface
{
    public interface IFolderRepository : IBaseRepository<FolderEntity>
    {
        Task CreateFisicalFolder(FolderEntity path);
        Task<List<string>> ReadFisicalFolders();
    }
}
