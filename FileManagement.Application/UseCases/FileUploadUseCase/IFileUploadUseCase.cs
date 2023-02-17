using FileManagement.Shared.Communication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement.Application.UseCases.FileUploadUseCase
{
    public interface IFileUploadUseCase
    {
        Task<bool> Execute(UploadFileRequest fileName);
    }
}
