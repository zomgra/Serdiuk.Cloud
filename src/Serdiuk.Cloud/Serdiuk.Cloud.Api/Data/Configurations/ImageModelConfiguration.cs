using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Serdiuk.Cloud.Api.Data.Entity;

namespace Serdiuk.Cloud.Api.Data.Configurations
{
    public class ImageModelConfiguration : IEntityTypeConfiguration<FileObject>
    {
        public void Configure(EntityTypeBuilder<FileObject> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.UserId);

            builder.HasIndex(x => x.UserId);
        }
    }
}
