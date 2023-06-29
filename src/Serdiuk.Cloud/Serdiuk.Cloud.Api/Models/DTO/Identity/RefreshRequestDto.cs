namespace Serdiuk.Cloud.Api.Models.DTO.Identity
{
    public class RefreshRequestDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
