using Dokumentenmanagement.Shared.Model;
using Dokumentenmanagement.Web.Models.Documents;
using System;

namespace Dokumentenmanagement.Api.Model.Documents
{
    public class DocumentOverview
    {
        public DocumentOverview(Guid? id, string displayName, FileType fileType, string? description, DateTime? originCreationDate, DateTime creationDate, DateTime? changeDate)
        {
            this.Id = id;
            this.DisplayName = displayName;
            this.FileType = fileType;
            this.Description = description;
            this.OriginCreationDate = originCreationDate;
            this.CreationDate = creationDate;
            this.ChangeDate = changeDate;
        }

        public Guid? Id { get; set; }
        public string DisplayName { get; set; }
        public string? Description { get; set; }
        public FileType FileType { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? OriginCreationDate { get; set; }
        public DateTime? ChangeDate { get; set; }

        public static DocumentOverview FromDto(DocumentDto documentDto)
        {
            return new DocumentOverview(documentDto.Id, documentDto.DisplayName, FileType.FromDto(documentDto.FileType), documentDto.Description, documentDto.OriginCreationDate, documentDto.CreationDate, documentDto.ChangeDate);
        }
    }
}
