using Dokumentenmanagement.Api.Model.Documents;
using Dokumentenmanagement.Repository.Document;
using Dokumentenmanagement.Repository.FileType;
using Dokumentenmanagement.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dokumentenmanagement.Api.Controllers
{

    [Route("api/v1/[controller]")]
    public class DocumentsController : Controller
    {
        private readonly IDocumentRepository documentRepository;
        private readonly IFileTypeRepository fileTypeRepository;

        public DocumentsController(IDocumentRepository documentRepository, IFileTypeRepository fileTypeRepository)
        {
            this.documentRepository = documentRepository;
            this.fileTypeRepository = fileTypeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UploadDocument(string displayName, IFormFile file, int fileTypeId, string? description = null, DateTime? originCreationDate = null)
        {
            if (file.Length <= 0)
            {
                return this.BadRequest("File has invalid length of zero.");
            }

            using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            var fileBytes = memoryStream.ToArray();

            var fileTypeDto = await this.fileTypeRepository.GetFileType(fileTypeId);

            if (fileTypeDto == null)
            {
                return this.BadRequest("Given FileType is not valid.");
            }

            var document = new DocumentDto(displayName, fileBytes, fileTypeDto, description, originCreationDate);
            document = await this.documentRepository.CreateDocument(document);

            if (document == null)
            {
                return this.Conflict("Document could not be created.");
            }

            return CreatedAtRoute(
                routeName: "SingleDocument",
                routeValues: new { id = document.Id },
                value: document);
        }

        [HttpGet]
        public async Task<IActionResult> GetDocuments([FromQuery] DocumentSearchModel searchModel)
        {
            var documents = await this.documentRepository.GetDocuments(searchModel);
            return this.Ok(documents.Select(DocumentOverview.FromDto));
        }

        [HttpGet("{id}", Name = "SingleDocument")]
        public async Task<IActionResult> GetDocument([FromRoute] Guid id)
        {
            var document = await this.documentRepository.GetDocument(id);
            //TODO: api model
            return this.Ok(document);
        }
    }
}
