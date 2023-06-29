using FluentResults;
using Serdiuk.Cloud.Api.Data.Entity;

namespace Serdiuk.Cloud.Api.Infrastructure.Interfaces
{
    public interface IFileService
    {
        Task<Result<IEnumerable<FileObject>>> GetFilesByUserIdAsync(string userId);
        Task<Result<FileObject>> GetFileByIdAsync(Guid id, string userId);
        Task<Result> DeleteFileByIdAsync(Guid id);
        Task<Result> UploadFileAsync(IFormFile file, string userId, bool isPublic=false);
        Task<Result> ChangeFilePublicAsync(Guid id, string userId);
        Task<Result> RenameFileAsync(string name, Guid id, string userId);
    }
}
