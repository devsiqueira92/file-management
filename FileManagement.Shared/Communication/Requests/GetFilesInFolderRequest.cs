using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement.Shared.Communication.Requests
{
    public class GetFilesInFolderRequest
    {
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
    }
}
