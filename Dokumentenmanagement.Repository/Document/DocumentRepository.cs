using Dokumentenmanagement.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dokumentenmanagement.Repository.Document
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DocumentContext context;

        public DocumentRepository(DocumentContext context)
        {
            this.context = context;
        }

        public async Task<DocumentDto?> CreateDocument(DocumentDto document)
        {
            var fileTypeDao = await this.context.FileTypes.FirstOrDefaultAsync(x => x.Id == document.FileType.Id);

            if (fileTypeDao == null)
            {
                return null;
            }

            var dao = DocumentDao.Create(document.DisplayName, document.Content, fileTypeDao, document.Description, document.OriginCreationDate);
            this.context.Documents.Add(dao);

            await this.context.SaveChangesAsync();
            return dao.ToDto(document.FileType);
        }

        public async Task<bool> DeleteDocument(Guid id)
        {
            var dao = await this.context.Documents.FirstOrDefaultAsync(x => x.Id == id);

            if (dao == null)
            {
                return false;
            }

            this.context.Documents.Remove(dao);
            await this.context.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public async Task<DocumentDto?> GetDocument(Guid id)
        {
            var dao = await this.context.Documents.FirstOrDefaultAsync(x => x.Id == id);
            return dao.ToDto(dao.FileType.ToDto());
        }

        public async Task<List<DocumentDto>> GetDocuments(DocumentSearchModel searchModel)
        {
            var daos = await this.context.Documents.Include(x => x.FileType).ToListAsync();
            var fileTypes = daos
                .Select(x => x.FileType.ToDto())
                .Distinct()
                .ToList();

            return daos.Select(dao => dao.ToDto(fileTypes.First(fileType => fileType.Id == dao.FileType.Id))).ToList();
        }

        public async Task<DocumentDto> UpdateDocument(DocumentDto document)
        {
            var dao = await this.context.Documents.FirstOrDefaultAsync(x => x.Id == document.Id);
            
            if (dao == null)
            {
                return document;
            }

            var fileTypeDao = await this.context.FileTypes.FirstOrDefaultAsync(x => x.Id == document.FileType.Id);

            dao.Update(document.DisplayName, document.Content, fileTypeDao, document.Description, document.OriginCreationDate);

            await this.context.SaveChangesAsync();

            return dao.ToDto(fileTypeDao.ToDto());
        }
    }
}
