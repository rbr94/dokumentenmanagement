using System;

namespace Dokumentenmanagement.Shared.Model
{
    public class DocumentDto
    {
        public DocumentDto(string displayName, byte[] content, FileTypeDto fileType, string? description = null, DateTime? originCreationDate = null)
        {
            this.DisplayName = displayName;
            this.Content = content;
            this.FileType = fileType;
            this.Description = description;
            this.OriginCreationDate = originCreationDate;
        }

        public DocumentDto(Guid id, string displayName, byte[] content, FileTypeDto fileType, string? description, DateTime? originCreationDate, DateTime creationDate, DateTime? changeDate)
        {
            this.Id = id;
            this.DisplayName = displayName;
            this.Content = content;
            this.FileType = fileType;
            this.Description = description;
            this.OriginCreationDate = originCreationDate;
            this.CreationDate = creationDate;
            this.ChangeDate = changeDate;
        }

        public Guid? Id { get; set; }
        public string DisplayName { get; set; }
        public string? Description { get; set; }
        public byte[] Content { get; set; }
        public FileTypeDto FileType { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? OriginCreationDate { get; set; }
        public DateTime? ChangeDate { get; set; }
    }
}
