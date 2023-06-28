using Microsoft.AspNetCore.Mvc;

namespace Serdiuk.Cloud.Api.Models
{
    public class FileResponse
    {
        public Guid Id { get; set; }
        public FileContentResult Data { get; set; }
    }
}
