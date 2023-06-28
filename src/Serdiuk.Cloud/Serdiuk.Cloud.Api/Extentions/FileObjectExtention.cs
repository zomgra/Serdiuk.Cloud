using Serdiuk.Cloud.Api.Data.Entity;
using System.Net.Http.Headers;
using MimeMapping;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace Serdiuk.Cloud.Api.Extentions
{
    public static class FileObjectExtention
    {
        //public static HttpResponseMessage ConvertFilesObjectToResponceMessage(this IEnumerable<FileObject> fileObjects)
        //{
        //    var multipartContent = new MultipartContent();

        //    foreach (var file in fileObjects)
        //    {
        //        var fileContent = new ByteArrayContent(file.Data);
        //        fileContent.Headers.ContentType = new MediaTypeHeaderValue(GetMimeType(file.Name));

        //        var fileContentDisposition = new ContentDispositionHeaderValue("attachment")
        //        {
        //            FileName = file.Name
        //        };
        //        fileContent.Headers.ContentDisposition = fileContentDisposition;

        //        multipartContent.Add(fileContent);
        //    }

        //    var response = new HttpResponseMessage();
        //    response.Content = multipartContent;
        //    return response;
        //}
        //public static FileContentResult ConvertFileObjectToResponceMessage(this FileObject fileObject)
        //{
        //    var content = new FileContentResult(fileObject.Data, GetMimeType(fileObject.Name));
        //    return content;
        //}
        public static string GetMimeType(this FileObject fileObject)
        {
            string contentType;
            new FileExtensionContentTypeProvider().TryGetContentType(fileObject.Name, out contentType);
            return contentType;
        }
    }
}
