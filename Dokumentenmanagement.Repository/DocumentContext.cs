using Dokumentenmanagement.Repository.Document;
using Dokumentenmanagement.Repository.FileType;
using Microsoft.EntityFrameworkCore;

namespace Dokumentenmanagement.Repository
{
    public class DocumentContext : DbContext
    {
        public DocumentContext(DbContextOptions<DocumentContext> options) : base(options)
        {
        }

        public DbSet<DocumentDao> Documents { get; private set; }
        public DbSet<FileTypeDao> FileTypes { get; private set; }
    }
}
