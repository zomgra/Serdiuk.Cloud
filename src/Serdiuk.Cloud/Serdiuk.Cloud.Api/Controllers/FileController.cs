using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serdiuk.Cloud.Api.Infrastructure.Interfaces;

namespace Serdiuk.Cloud.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly string UserId;
        public FileController(IFileService fileService, UserManager<IdentityUser> userManager)
        {
            _fileService = fileService;
            UserId = userManager.GetUserId(User);
        }
     
        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            var result = await _fileService.UploadFileAsync(file, UserId);
            return HandleResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetFilesByUserId()
        {
            var result = await _fileService.GetFilesByUserIdAsync(UserId);
            return HandleResult(result);
        }



        private IActionResult HandleResult<T>(Result<T> result)
        {
            if (!result.IsSuccess)
                return BadRequest(string.Join(", ", result.Errors.Select(x => x.Reasons)));
            return Ok(result.Value);
        }
        private IActionResult HandleResult(Result result)
        {
            if (!result.IsSuccess)
                return BadRequest(string.Join(", ", result.Errors.Select(x => x.Reasons)));
            return Ok(result);
        }
    }
}
