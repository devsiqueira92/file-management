using FileManagement.Domain.Entities;
using FileManagement.Shared.Communication.Requests;
using FileManagement.Shared.Communication.Responses;

namespace FileManagement.Application.UseCases.FolderReadUseCase
{
    public interface IFolderReadUseCase
    {
        Task<List<FolderResponse>> Execute();
    }
}
