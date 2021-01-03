using Dokumentenmanagement.Shared.Model;

namespace Dokumentenmanagement.Web.Models.Documents
{
    public class FileType
    {
        public FileType(int id, string name, string suffix, string? icon = null)
        {
            this.Id = id;
            this.Name = name;
            this.Suffix = suffix;
            this.Icon = icon;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Suffix { get; set; }
        public string? Icon { get; set; }

        public static FileType FromDto(FileTypeDto fileTypeDto)
        {
            return new FileType(fileTypeDto.Id, fileTypeDto.Name, fileTypeDto.Suffix, fileTypeDto.Icon);
        }
    }
}
