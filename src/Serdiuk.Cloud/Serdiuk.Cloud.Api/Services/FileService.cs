using FluentResults;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Cloud.Api.Data;
using Serdiuk.Cloud.Api.Data.Entity;
using Serdiuk.Cloud.Api.Infrastructure.Interfaces;

namespace Serdiuk.Cloud.Api.Services
{
    public class FileService : IFileService
    {
        private readonly AppDbContext _context;

        public FileService(AppDbContext context)
        {
            _context = context;
        }

        public Task<Result> DeleteFileByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<FileObject>> GetFileByIdAsync(Guid id, string userId)
        {
            var entity = await _context.Files.FirstOrDefaultAsync(x=>x.Id == id);
            if (entity == null)
                return Result.Fail("File not found");
            if (entity.UserId != userId)
                return Result.Fail("You haven`t permissions for wathing this file");
            return Result.Ok(entity);
        }

        public async Task<Result<IEnumerable<FileObject>>> GetFilesByUserIdAsync(string userId)
        {
            var entity = _context.Files.Where(x => x.UserId == userId).AsEnumerable();
            if (entity == null || !entity.Any())
                return Result.Fail("Files not found");

            return Result.Ok(entity);
        }

        public Task<Result> RenameFileAsync(string name, Guid id, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> UploadFileAsync(IFormFile file, string userId)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    var newFile = new FileObject
                    {
                        Data = ms.ToArray(),
                        Name = file.FileName,
                        UserId = userId,
                    };
                    await _context.Files.AddAsync(newFile);
                    await _context.SaveChangesAsync();
                    return Result.Ok();
                }
            }
            catch
            {
                return Result.Fail("Saving Failure");
            }
        }

        public Task<Result> UploadManyFilesAsync(IFormFileCollection file, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
