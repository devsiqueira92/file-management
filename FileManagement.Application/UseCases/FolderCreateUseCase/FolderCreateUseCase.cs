using AutoMapper;
using FileManagement.Domain.Entities;
using FileManagement.Domain.RepositoryInterface;
using FileManagement.Shared.Communication.Requests;

namespace FileManagement.Application.UseCases.FolderCreateUseCase
{
    internal class FolderCreateUseCase : IFolderCreateUseCase
    {
        private readonly IFolderRepository _folderRepository;
        private readonly IMapper _mapper;

        public FolderCreateUseCase(IFolderRepository folderRepository, IMapper mapper)
        {
            _folderRepository = folderRepository;
            _mapper = mapper;
        }

        public async Task Execute(CreateFolderRequest request)
        {
            FolderEntity entity = _mapper.Map<FolderEntity>(request);

            entity.FolderPath += "EmptyNewFolder";

            await _folderRepository.CreateFisicalFolder(entity);
        }
    }
}
