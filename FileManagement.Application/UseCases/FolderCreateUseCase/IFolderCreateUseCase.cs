using FileManagement.Shared.Communication.Requests;

namespace FileManagement.Application.UseCases.FolderCreateUseCase
{
    public interface IFolderCreateUseCase
    {
        Task Execute(CreateFolderRequest request);
    }
}
