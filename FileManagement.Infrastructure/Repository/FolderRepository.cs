using FileManagement.Domain.Entities;
using FileManagement.Domain.RepositoryInterface;

namespace FileManagement.Infrastructure.Repository
{
    public class FolderRepository : BaseRepository<FolderEntity>, IFolderRepository
    {
        private readonly string _basePath;
        public FolderRepository(string basePath)
        {
            _basePath = basePath;
        }
        public async Task CreateFisicalFolder(FolderEntity entity)
        {
            await Task.Run(() => {
                var basePath = @$"{_basePath}\{entity.FolderPath}";
                basePath = basePath.Replace("EmptyNewFolder", @"\");
                Directory.CreateDirectory($"{basePath}{entity.FolderName}");
            });
            
        }

        public async Task<List<string>> ReadFisicalFolders()
        {
            var listFolders = await Task.Run(() => {
                string searchPattern = "*";
                var basePath = @$"{_basePath}";

                var directories = new List<string>(GetDirectories(basePath, searchPattern));

                for (var i = 0; i < directories.Count; i++)
                    directories.AddRange(GetDirectories(directories[i], searchPattern));

                return directories;
            });
            return listFolders;
        }

        private static List<string> GetDirectories(string path, string searchPattern)
        {
            try
            {
                return Directory.GetDirectories(path, searchPattern).ToList();
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
        }
    }
}
