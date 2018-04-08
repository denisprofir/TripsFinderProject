using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripsFinder.DAL.Models;
using TripsFinder.DAL.Models.Concrete;

namespace TripsFinder.DAL.ModelsConfigs
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
