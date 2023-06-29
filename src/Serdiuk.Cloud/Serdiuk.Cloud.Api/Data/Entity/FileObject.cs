﻿namespace Serdiuk.Cloud.Api.Data.Entity
{
    public class FileObject
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public string FilePath { get; set; }
    }
}
