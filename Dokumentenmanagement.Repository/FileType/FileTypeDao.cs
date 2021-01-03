using Dokumentenmanagement.Shared.Model;
using System;

namespace Dokumentenmanagement.Repository.FileType
{
    public class FileTypeDao
    {
        public FileTypeDao(int id, string name, string suffix, string? icon = null)
        {
            this.Id = id;
            this.Name = name;
            this.Suffix = suffix;
            this.Icon = icon;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Suffix { get; private set; }
        public string? Icon { get; private set; }

        public FileTypeDto ToDto()
        {
            return new FileTypeDto(this.Id, this.Name, this.Suffix, this.Icon);
        }
    }
}
