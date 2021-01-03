using Microsoft.AspNetCore.Http;
using System;

namespace Dokumentenmanagement.Web.Models.Documents
{
    public class UploadDocument
    {
        public UploadDocument(string displayName, IFormFile file, int fileTypeId, string? description = null, DateTime? originCreationDate = null)
        {
            this.DisplayName = displayName;
            this.File = file;
            this.FileTypeId = fileTypeId;
            this.Description = description;
            this.OriginCreationDate = originCreationDate;
        }

        public string DisplayName { get; set; }
        public string? Description { get; set; }
        public IFormFile File { get; set; }
        public DateTime? OriginCreationDate { get; set; }
        public int FileTypeId { get; set; }
    }
}
