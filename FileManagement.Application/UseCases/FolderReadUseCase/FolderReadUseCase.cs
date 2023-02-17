using FileManagement.Domain.RepositoryInterface;
using FileManagement.Shared.Communication.Responses;

namespace FileManagement.Application.UseCases.FolderReadUseCase
{
    public class FolderReadUseCase : IFolderReadUseCase
    {
        private readonly IFolderRepository _folderRepository;

        public FolderReadUseCase(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }
        public async Task<List<FolderResponse>> Execute()
        {
            var listFolders = await _folderRepository.ReadFisicalFolders();

            var tree = Convert(listFolders);

            return tree;
        }

        private List<FolderResponse> Convert(List<string> paths)
        {
            var rootFolders = new List<FolderResponse>();

            foreach (var path in paths)
            {
                var folderNames = path.Split('\\');

                // Skip empty paths or root folder
                if (folderNames.Length == 0 || folderNames[0] == "")
                {
                    continue;
                }

                var currentFolder = rootFolders.FirstOrDefault(f => f.FolderName == folderNames[0]);
                if (currentFolder == null)
                {
                    currentFolder = new FolderResponse { FolderName = folderNames[0], Subfolders = new List<FolderResponse>() };
                    rootFolders.Add(currentFolder);
                }

                for (int i = 1; i < folderNames.Length; i++)
                {
                    var subFolder = currentFolder.Subfolders.FirstOrDefault(f => f.FolderName == folderNames[i]);
                    if (subFolder == null)
                    {
                        subFolder = new FolderResponse { FolderName = folderNames[i], Subfolders = new List<FolderResponse>() };
                        currentFolder.Subfolders.Add(subFolder);
                    }
                    currentFolder = subFolder;
                }
            }

            return rootFolders;
        }
    }
}
