using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement.Shared.Communication.Responses
{
    public class FolderResponse
    {
        public string FolderName { get; set; }
        public bool IsDirectory { get; set; } = true;
        public List<FolderResponse> Subfolders { get; set; }
    }
}
