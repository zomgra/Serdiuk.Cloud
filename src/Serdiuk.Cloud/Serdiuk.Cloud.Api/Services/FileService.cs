using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Cloud.Api.Data;
using Serdiuk.Cloud.Api.Data.Entity;
using Serdiuk.Cloud.Api.Infrastructure.Interfaces;
using System.IO;

namespace Serdiuk.Cloud.Api.Services
{
    public class FileService : IFileService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public Task<Result> DeleteFileByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<FileObject>> GetFileByIdAsync(Guid id, string userId)
        {
            var fileDirectory = Path.Combine(_webHostEnvironment.ContentRootPath + "files", userId);
            if (!Directory.Exists(fileDirectory))
            {
                return Result.Fail("No found file");
            }
            var file = await _context.Files.FirstOrDefaultAsync(x => x.Id == id);
            if (file == null)
                return Result.Fail("No found file");
            if (file.UserId != userId)
                return Result.Fail("It`s not your file");

            return file;
        }

        public async Task<Result> UploadFileAsync(IFormFile file, string userId)
        {
            var fileDirectory = Path.Combine(_webHostEnvironment.ContentRootPath, "files", userId);
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }
            var id = Guid.NewGuid();
            var fileName = id + "_" + file.FileName;
            var filePath = Path.Combine(fileDirectory, fileName);
            try
            {
                var requestFileStream = file.OpenReadStream();

                using (var fs = File.OpenWrite(filePath))
                {
                    await requestFileStream.CopyToAsync(fs);
                    var newFile = new FileObject
                    {
                        FilePath = filePath,
                        Name = file.FileName,
                        Id = id,
                        UserId = userId,
                    };
                    await _context.AddAsync(newFile);
                    await _context.SaveChangesAsync();
                }

                return Result.Ok();
            }
            catch(Exception ex)
            {
                return Result.Fail("Error save file: " + ex.Message);
            }

        }
        public Task<Result<IEnumerable<FileObject>>> GetFilesByUserIdAsync(string userId)
        {
            var entities = _context.Files.Where(x => x.UserId == userId).AsEnumerable();
            if (entities == null || !entities.Any())
            {
                return Task.FromResult(Result.Fail<IEnumerable<FileObject>>("Files not found"));
            }
            return Task.FromResult(Result.Ok(entities));
        }

        public Task<Result> RenameFileAsync(string name, Guid id, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
