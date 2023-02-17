using FileManagement.Shared.Communication.Requests;

namespace FileManagement.Application.UseCases.FileMoveUseCase
{
    public interface IFileMoveUseCase
    {
        Task Execute(MoveFileRequest request);
    }
}
