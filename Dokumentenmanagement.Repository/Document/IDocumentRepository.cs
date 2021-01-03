using Dokumentenmanagement.Shared.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dokumentenmanagement.Repository.Document
{
    public interface IDocumentRepository : IDisposable
    {
        Task<DocumentDto?> CreateDocument(DocumentDto document);
        Task<DocumentDto?> GetDocument(Guid id);
        Task<List<DocumentDto>> GetDocuments(DocumentSearchModel searchModel);
        Task<DocumentDto> UpdateDocument(DocumentDto document);
        Task<bool> DeleteDocument(Guid id);
    }
}
