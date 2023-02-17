using AutoMapper;
using FileManagement.Domain.Entities;
using FileManagement.Domain.RepositoryInterface;
using FileManagement.Shared.Communication.Requests;
using FileManagement.Shared.Communication.Responses;

namespace FileManagement.Application.UseCases.FileReadUseCase
{
    public class FileReadUseCase : IFileReadUseCase
    {
        private readonly IFileRepository _fileRepository; 
        private readonly IMapper _mapper;

        public FileReadUseCase(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }
        public async Task<List<FileResponse>> Execute(GetFilesInFolderRequest file)
        {
            var entity = _mapper.Map<FileEntity>(file);
            var files = await _fileRepository.ReadFisicalFiles(entity);

            var fileList = files.Select(item => new FileResponse { FilePath = item }).ToList();

            return fileList;

        }
    }
}
