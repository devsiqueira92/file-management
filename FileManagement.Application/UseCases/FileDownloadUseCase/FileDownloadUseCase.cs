using AutoMapper;
using FileManagement.Domain.Entities;
using FileManagement.Domain.RepositoryInterface;
using FileManagement.Shared.Communication.Requests;
using FileManagement.Shared.Communication.Responses;

namespace FileManagement.Application.UseCases.FileDownloadUseCase
{
    public class FileDownloadUseCase : IFileDownloadUseCase
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;

        public FileDownloadUseCase(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        public async Task<DownloadFileResponse> Execute(DownloadFileRequest url)
        {
            var entity = _mapper.Map<FileEntity>(url);
            var fileToDownload = await _fileRepository.DownloadFile(entity);

          
            var objectDownload = new DownloadFileResponse();
            objectDownload.FileName = "FileDownloaded";
            objectDownload.ContentType = "image/png";
            objectDownload.Content = fileToDownload;

            return objectDownload;
        }
    }
}
