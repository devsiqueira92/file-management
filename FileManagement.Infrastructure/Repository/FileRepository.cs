using FileManagement.Domain.Entities;
using FileManagement.Domain.RepositoryInterface;
using FileManagement.Shared.Exceptions;

namespace FileManagement.Infrastructure.Repository
{
    public class FileRepository : BaseRepository<FileEntity>, IFileRepository
    {
        private readonly string _basePath;
        public FileRepository(string basePath)
        {
            _basePath = basePath;            
        }

        public async Task<List<string>> ReadFisicalFiles(FileEntity file)
        {
            var files = await Task.Run(() => {
                var basePath = @$"{_basePath}\{file.FilePath}";

                if (!Directory.Exists(basePath))
                {
                    throw new ValidationErrorsExceptions(ResourceErrorsMessage.FOLDER_NOT_FOUND);
                }
                return Directory.GetFiles(basePath).ToList();
            });
            return files;
        }

        public async Task<bool> UploadFile(FileEntity file)
        {
            var filePath = @$"{_basePath}";
            if (!Directory.Exists(filePath))
            {
                throw new ValidationErrorsExceptions(ResourceErrorsMessage.FOLDER_NOT_FOUND);
            }

            filePath += file.FileData.FileName;

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.FileData.CopyToAsync(stream);
                return true;
            }
        }

        public async Task<byte[]> DownloadFile(FileEntity file)
        {
            var fileLocation = GetFilePath(file.FileName, file.FilePath);

            return await Task.Run(() => {
                var file = File.ReadAllBytes(fileLocation);
                return file;
            });
        }

        public async Task MoveFile(FileEntity file, string destinationPath)
        {
            var fileLocation = GetFilePath(file.FileName, file.FilePath);

            await Task.Run(() => {
                File.Move(fileLocation, destinationPath, true);
            });
        }

        private string GetFilePath(string fileName, string filePath)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ValidationErrorsExceptions(ResourceErrorsMessage.EMPTY_FILE_NAME);
            }

            if (!Directory.Exists(filePath))
            {
                throw new ValidationErrorsExceptions(ResourceErrorsMessage.FOLDER_NOT_FOUND);
            }

           
            var file = new FileInfo($"{filePath}/{fileName}");

            if (!file.Exists)
            {
                throw new ValidationErrorsExceptions(ResourceErrorsMessage.FILE_NOT_FOUND);
            }

            return file.FullName;
        }
    }
}
