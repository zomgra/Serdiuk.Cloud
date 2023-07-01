using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Cloud.Api.Data;
using Serdiuk.Cloud.Api.Data.Entity;
using Serdiuk.Cloud.Api.Infrastructure.Interfaces;

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

        public async Task<Result> DeleteFileByIdAsync(Guid id, string userId)
        {
            var entity = await _context.Files.FirstOrDefaultAsync(x=>x.Id==id);

            if (entity == null) return Result.Fail("File not found");
            if (entity.UserId != userId) return Result.Fail("Your haven`t perrmisions to delete this file");

            try
            {
                var filePath = entity.FilePath;
                if (File.Exists(filePath))
                {
                 //   File.Delete(filePath);  // For deleting file in provide system

                    entity.IsRemove = true;
                    await _context.SaveChangesAsync();
                    return Result.Ok();
                }
                else
                {
                    Result.Fail("File not exists.");
                }
            }
            catch (Exception ex)
            {
                Result.Fail("Error with deleting file: " + ex.Message);
            }

            return Result.Ok();
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

            if (!file.IsPublic && file.UserId != userId)
                return Result.Fail("File is private");

            return file;
        }

        public async Task<Result> UploadFileAsync(IFormFile file, string userId, bool isPublic = false)
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
                        IsPublic = isPublic
                    };
                    await _context.AddAsync(newFile);
                    await _context.SaveChangesAsync();
                }

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail("Error save file: " + ex.Message);
            }

        }
        public async Task<Result<List<FileObject>>> GetFilesByUserIdAsync(string userId)
        {
            var entities =  await _context.Files.Where(x => x.UserId == userId).ToListAsync();
            if (entities == null || !entities.Any())
            {
                return Result.Fail("Files not found");
            }
            return Result.Ok(entities);
        }

        public async Task<Result> RenameFileAsync(string name, Guid id, string userId)
        {
            var entity = await _context.Files.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return Result.Fail("File not found");

            if (entity.UserId != userId)
                return Result.Fail("Is not your file");

            var path = entity.FilePath;
            var oldName = entity.Name;
            try
            {
                string directory = Path.GetDirectoryName(path);
                var newName = (entity.Id+ "_"+ name);
                string newFilePath = Path.Combine(directory, newName);
                newFilePath = Path.ChangeExtension(newFilePath, Path.GetExtension(path));

                if (File.Exists(path))
                {
                    File.Move(path, newFilePath);
                    entity.Name = name + Path.GetExtension(path);
                    entity.FilePath = newFilePath;
                    await _context.SaveChangesAsync();
                    return Result.Ok();
                }
                else
                {
                    Result.Fail("File not found.");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail("Error with saving: " + ex.Message);
            }
            return Result.Fail("Error with saving");
        }

        public async Task<Result> ChangeFilePublicAsync(Guid id, string userId)
        {
            var entity = await _context.Files.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return Result.Fail("File not found");
            if (entity.UserId != userId) return Result.Fail("You haven`t permissions to change this file");

            entity.IsPublic = !entity.IsPublic;
            await _context.SaveChangesAsync();
            return Result.Ok();
        }
    }
}
