using FileManagement.Shared.Communication.Requests;
using FileManagement.Shared.Communication.Responses;

namespace FileManagement.Application.UseCases.FileDownloadUseCase
{
    public interface IFileDownloadUseCase
    {
        Task<DownloadFileResponse> Execute(DownloadFileRequest url);
    }
}
