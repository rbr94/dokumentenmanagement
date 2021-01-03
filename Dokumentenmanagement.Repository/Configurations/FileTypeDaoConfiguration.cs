using Dokumentenmanagement.Repository.FileType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dokumentenmanagement.Repository.Configurations
{
    public class FileTypeDaoConfiguration : IEntityTypeConfiguration<FileTypeDao>
    {
        public void Configure(EntityTypeBuilder<FileTypeDao> builder)
        {
            builder.ToTable("FileTypes");
        }
    }
}
