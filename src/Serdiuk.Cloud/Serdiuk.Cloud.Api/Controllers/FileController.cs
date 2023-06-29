using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serdiuk.Cloud.Api.Exceptions;
using Serdiuk.Cloud.Api.Extentions;
using Serdiuk.Cloud.Api.Infrastructure.Interfaces;
using Serdiuk.Cloud.Api.Models;
using Serdiuk.Cloud.Api.Models.DTO.File;

namespace Serdiuk.Cloud.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        public FileController(IFileService fileService, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _fileService = fileService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFileAsync([FromBody] UploadFileRequestDto dto)
        {
            var userId = _userManager.GetUserId(User);
            var result = await _fileService.UploadFileAsync(dto.File, userId, dto.IsPublic);

            HandleResult(result);

            return Ok();
        }

        [HttpPost("rename")]
        public async Task<IActionResult> RenameFileAsync([FromBody] RenameFileRequestDto dto)
        {
            var userId = _userManager.GetUserId(User);
            var result = await _fileService.RenameFileAsync(dto.NewName, dto.Id, userId);

            HandleResult(result);

            return Ok();
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetFilesByUserId()
        {
            var userId = _userManager.GetUserId(User);
            var result = await _fileService.GetFilesByUserIdAsync(userId);
            HandleResult(result);

            var response = _mapper.Map<List<FileViewModel>>(result.Value);

            return Ok(response);
        }

        [HttpGet("download/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFileByIdAsync(Guid id)
        {
            var userId = _userManager.GetUserId(User);
            var result = await _fileService.GetFileByIdAsync(id, userId);
            HandleResult(result);

            var stream = new FileStream(result.Value.FilePath, FileMode.Open);

            return File(stream, result.Value.GetMimeType(), result.Value.Name);
        }
        private void HandleResult(ResultBase result)
        {
            if (!result.IsSuccess)
                throw new CloudBadRequestException(string.Join(", ", result.Reasons.Select(x => x.Message)));
        }
    }
}
