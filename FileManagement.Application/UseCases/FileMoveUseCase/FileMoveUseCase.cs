using AutoMapper;
using FileManagement.Domain.Entities;
using FileManagement.Domain.RepositoryInterface;
using FileManagement.Shared.Communication.Requests;

namespace FileManagement.Application.UseCases.FileMoveUseCase
{
    public class FileMoveUseCase : IFileMoveUseCase
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;
        public FileMoveUseCase(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }
        public async Task Execute(MoveFileRequest request)
        {
            var entity = _mapper.Map<FileEntity>(request);

            await _fileRepository.MoveFile(entity, request.DestinationPath);
        }
    }
}
