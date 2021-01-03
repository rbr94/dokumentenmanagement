using Dokumentenmanagement.Shared.Model;
using System;
using System.Threading.Tasks;

namespace Dokumentenmanagement.Repository.FileType
{
    public interface IFileTypeRepository : IDisposable
    {
        Task<FileTypeDto?> GetFileType(int id);
    }
}
