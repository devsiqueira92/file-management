using FileManagement.Application.UseCases.FolderCreateUseCase;
using FileManagement.Application.UseCases.FolderReadUseCase;
using FileManagement.Shared.Communication.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FileManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateFolder(
            [FromServices] IFolderCreateUseCase useCase,
            [FromBody] CreateFolderRequest request)
        {
            await useCase.Execute(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetFolders(
           [FromServices] IFolderReadUseCase useCase)
        {
            CreateFolderRequest request = new();
            var r = await useCase.Execute();
            return Ok(r);
        }
    }
}
