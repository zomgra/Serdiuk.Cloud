namespace Serdiuk.Cloud.Api.Models.DTO.File
{
    public class UploadFileRequestDto
    {
        public IFormFile File { get; set; }
        public bool IsPublic { get; set; }
    }
}
