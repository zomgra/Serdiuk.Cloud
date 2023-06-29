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
        public static string GetMimeType(this FileObject fileObject)
        {
            string contentType;
            new FileExtensionContentTypeProvider().TryGetContentType(fileObject.Name, out contentType);
            return contentType;
        }
    }
}
