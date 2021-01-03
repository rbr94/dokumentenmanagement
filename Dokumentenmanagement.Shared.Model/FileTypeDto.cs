using System;
using System.Collections.Generic;
using System.Text;

namespace Dokumentenmanagement.Shared.Model
{
    public class FileTypeDto
    {
        public FileTypeDto(int id, string name, string suffix, string? icon = null)
        {
            this.Id = id;
            this.Name = name;
            this.Suffix = suffix;
            this.Icon = icon;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Suffix { get; set; }

        public string? Icon { get; private set; }

        public override bool Equals(object? obj)
        {
            return obj is FileTypeDto dao &&
                   this.Id == dao.Id &&
                   this.Name == dao.Name &&
                   this.Suffix == dao.Suffix;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Name, this.Suffix);
        }
    }
}
