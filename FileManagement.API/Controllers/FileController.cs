using FileManagement.Application.UseCases.FileDownloadUseCase;
using FileManagement.Application.UseCases.FileReadUseCase;
using FileManagement.Application.UseCases.FileUploadUseCase;
using FileManagement.Shared.Communication.Requests;
using FileManagement.Shared.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FileManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetFiles(
           [FromServices] IFileReadUseCase useCase, [FromBody] GetFilesInFolderRequest request)
        {
            var r = await useCase.Execute(request);
            return Ok(r);
        }

        [HttpPost("upload-file")]
        public async Task<IActionResult> UploadFile(
           [FromServices] IFileUploadUseCase useCase,
           IFormFile formFile)
        {

            UploadFileRequest file = new UploadFileRequest();
            file.FileData = formFile;

            var result = await useCase.Execute(file);
            return Created("", result);
        }

        [HttpPost("download-file")]
        public async Task<IActionResult> DownloadFile(
           [FromServices] IFileDownloadUseCase useCase,
           [FromBody] DownloadFileRequest file)
        {
            DownloadFileResponse result = await useCase.Execute(file);
            return File(result.Content, result.ContentType, result.FileName);
        }
    }
}
