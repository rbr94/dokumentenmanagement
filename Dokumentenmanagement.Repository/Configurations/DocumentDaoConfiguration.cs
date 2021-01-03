using Dokumentenmanagement.Repository.Document;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dokumentenmanagement.Repository.Configurations
{
    public class DocumentDaoConfiguration : IEntityTypeConfiguration<DocumentDao>
    {
        public void Configure(EntityTypeBuilder<DocumentDao> builder)
        {
            builder.ToTable("Documents");
            builder.HasOne(x => x.FileType).WithMany();
        }
    }
}
