using AutoMapper;
using FileManagement.Domain.Entities;
using FileManagement.Domain.RepositoryInterface;
using FileManagement.Shared.Communication.Requests;
using FileManagement.Shared.Exceptions;

namespace FileManagement.Application.UseCases.FileUploadUseCase
{
    internal class FileUploadUseCase : IFileUploadUseCase
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;

        public FileUploadUseCase(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }
    
        public async Task<bool> Execute(UploadFileRequest fileName)
        {
            FileEntity entity = _mapper.Map<FileEntity>(fileName);

            var isUploadedFile = await _fileRepository.UploadFile(entity);

            if (!isUploadedFile)
                throw new ValidationErrorsExceptions(ResourceErrorsMessage.UPLOAD_ERROR);
            
            await _fileRepository.AddAsync(entity);

            return isUploadedFile;
        }
    }
}
