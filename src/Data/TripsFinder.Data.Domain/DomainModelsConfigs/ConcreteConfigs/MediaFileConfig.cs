using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripsFinder.Data.Domain.DomainModels.Concrete;

namespace TripsFinder.Data.Domain.DomainModelsConfigs.ConcreteConfigs
{
    public class MediaFileConfig : IEntityTypeConfiguration<MediaFile>
    {
        public void Configure(EntityTypeBuilder<MediaFile> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.Path)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false);
        }
    }
}
