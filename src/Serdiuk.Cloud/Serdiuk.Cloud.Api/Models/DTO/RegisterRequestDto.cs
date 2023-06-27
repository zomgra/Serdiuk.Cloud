using System.ComponentModel.DataAnnotations;

namespace Serdiuk.Cloud.Api.Models.DTO
{
    public class RegisterRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
