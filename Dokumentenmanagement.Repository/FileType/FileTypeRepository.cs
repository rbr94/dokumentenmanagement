using Dokumentenmanagement.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dokumentenmanagement.Repository.FileType
{
    public class FileTypeRepository : IFileTypeRepository
    {
        private readonly DocumentContext context;

        public FileTypeRepository(DocumentContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public async Task<FileTypeDto?> GetFileType(int id)
        {
            var dao = await this.context.FileTypes.FirstOrDefaultAsync(x => x.Id == id);
            return dao?.ToDto();
        }
    }
}
