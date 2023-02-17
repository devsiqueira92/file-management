
namespace FileManagement.Domain.Entities
{
    public class FolderEntity : BaseEntity
    {
        public string FolderName { get; set; }
        public string FolderPath { get; set; }
        public bool IsDirectory { get; set; } = true;
    }
}
