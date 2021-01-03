using Dokumentenmanagement.Repository.FileType;
using Dokumentenmanagement.Shared.Model;
using System;

namespace Dokumentenmanagement.Repository.Document
{
    public class DocumentDao
    {
#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
        public DocumentDao() { }
#pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.

        public DocumentDao(Guid id, string displayName, byte[] content, FileTypeDao fileType, DateTime creationDate, string? description = null, DateTime? originCreationDate = null, DateTime? changeDate = null)
        {
            this.Id = id;
            this.DisplayName = displayName;
            this.Content = content;
            this.FileType = fileType;
            this.CreationDate = creationDate;
            this.Description = description;
            this.OriginCreationDate = originCreationDate;
            this.ChangeDate = changeDate;
        }

        public static DocumentDao Create(string displayName, byte[] content, FileTypeDao fileType, string? description = null, DateTime? originCreationDate = null)
        {
            return new DocumentDao(Guid.NewGuid(), displayName, content, fileType, DateTime.UtcNow, description, originCreationDate);
        }

        public Guid Id { get; private set; }
        public string DisplayName { get; private set; }
        public string? Description { get; private set; }
        public byte[] Content { get; private set; }
        public FileTypeDao FileType { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? OriginCreationDate { get; private set; }
        public DateTime? ChangeDate { get; private set; }

        public void Update(string displayName, byte[] content, FileTypeDao fileType, string? description = null, DateTime? originCreationDate = null)
        {
            this.DisplayName = displayName;
            this.Content = content;
            this.FileType = fileType;
            this.Description = description;
            this.OriginCreationDate = originCreationDate;

            this.ChangeDate = DateTime.UtcNow;
        }

        public DocumentDto ToDto(FileTypeDto fileType)
        {
            return new DocumentDto(this.Id, this.DisplayName, this.Content, fileType, this.Description, this.OriginCreationDate, this.CreationDate, this.ChangeDate);
        }
    }
}
