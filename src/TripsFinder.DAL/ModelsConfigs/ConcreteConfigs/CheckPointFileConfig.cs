using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripsFinder.DAL.Models;
using TripsFinder.DAL.Models.Concrete;

namespace TripsFinder.DAL.ModelsConfigs
{
    public class CheckPointFileConfig : IEntityTypeConfiguration<CheckPointFile>
    {
        public void Configure(EntityTypeBuilder<CheckPointFile> builder)
        {
            builder.HasKey(e => new { e.CheckPointId, e.MediaFileId });

            builder.HasOne(d => d.CheckPoint)
                .WithMany(p => p.CheckPointsFiles)
                .HasForeignKey(d => d.CheckPointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CheckPointsFiles_MediaFiles");

            builder.HasOne(d => d.MediaFile)
                .WithMany(p => p.CheckPointsFiles)
                .HasForeignKey(d => d.MediaFileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CheckPointsFiles_CheckPoints");
        }
    }
}
