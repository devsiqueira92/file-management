using FileManagement.Domain.Entities;
using FileManagement.Shared.Communication.Requests;
using FileManagement.Shared.Communication.Responses;

namespace FileManagement.Application.UseCases.FileReadUseCase
{
    public interface IFileReadUseCase
    {
        Task<List<FileResponse>> Execute(GetFilesInFolderRequest file);
    }
}
